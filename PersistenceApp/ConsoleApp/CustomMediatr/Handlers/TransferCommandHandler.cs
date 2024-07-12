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
            return;

        var transferEvent = new TransferredEvent(command.FromAccountId, command.ToAccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());

        var fromAccount = await _bankAccountRepository.GetByIdAsync(command.FromAccountId);
        var withDrawSucceeded = fromAccount.Apply(transferEvent);

        if (!withDrawSucceeded)
            return;

        var toAccount = await _bankAccountRepository.GetByIdAsync(command.ToAccountId);
        toAccount.Apply(transferEvent);

        await _eventStore.SaveEventAsync(transferEvent);
        Console.WriteLine($"TransferCommandHandler: FromAccountId={command.FromAccountId}, ToAccountId={command.ToAccountId}, Amount={command.Amount}");
    }
}