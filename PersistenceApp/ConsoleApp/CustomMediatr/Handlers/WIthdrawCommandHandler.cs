using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers;

internal class WithdrawCommandHandler : ICommandHandler<WithdrawCommand>
{
    private readonly IEventStore _eventStore;
    private readonly IBankAccountRepository _bankAccountRepository;

    public WithdrawCommandHandler(IEventStore eventStore, IBankAccountRepository bankAccountRepository)
    {
        _eventStore = eventStore;
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task HandleAsync(WithdrawCommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var withdrawEvent = new WithdrawnEvent(command.AccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());

        var bankAccount = await _bankAccountRepository.GetByIdAsync(command.AccountId);
        var succeeded = bankAccount.Apply(withdrawEvent);

        if (!succeeded) return;

        await _eventStore.SaveEventAsync(withdrawEvent);
        Console.WriteLine($"WithdrawCommandHandler: AccountId={command.AccountId}, Amount={command.Amount}");
    }
}