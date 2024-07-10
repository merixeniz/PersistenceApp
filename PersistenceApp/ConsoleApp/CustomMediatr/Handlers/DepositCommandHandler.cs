using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Entities;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers;

internal class DepositCommandHandler : ICommandHandler<DepositCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IBankAccountRepository _bankAccountRepository;

    public DepositCommandHandler(IEventStore eventStore, IBankAccountRepository bankAccountRepository)
    {
        _eventStore = eventStore;
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task HandleAsync(DepositCommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var depositEvent = new DepositedEvent(command.AccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());
        await _eventStore.SaveEventAsync(depositEvent);

        var bankAccount = await _bankAccountRepository.GetByIdAsync(command.AccountId);
        bankAccount.Apply(depositEvent);

        Console.WriteLine($"DepositCommandHandler: AccountId={command.AccountId}, Amount={command.Amount}");
    }
}