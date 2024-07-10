using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers;

internal class TransferCommandHandler : ICommandHandler<TransferCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IBankAccountRepository _bankAccountRepository;

    public TransferCommandHandler(IEventStore eventStore, IBankAccountRepository bankAccountRepository)
    {
        _eventStore = eventStore;
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task HandleAsync(TransferCommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var transferEvent = new TransferredEvent(command.FromAccountId, command.ToAccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());
        await _eventStore.SaveEventAsync(transferEvent);

        var fromAccount = await _bankAccountRepository.GetByIdAsync(command.FromAccountId);
        fromAccount.Apply(transferEvent);

        var toAccount = await _bankAccountRepository.GetByIdAsync(command.ToAccountId);
        toAccount.Apply(transferEvent);

        Console.WriteLine($"TransferCommandHandler: FromAccountId={command.FromAccountId}, ToAccountId={command.ToAccountId}, Amount={command.Amount}");
    }
}