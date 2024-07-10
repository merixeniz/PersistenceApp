using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers;

internal class WithdrawCommandHandler : ICommandHandler<WithdrawCommand>
{
    private readonly IEventStore _eventStore;

    public WithdrawCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task HandleAsync(WithdrawCommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var withdrawEvent = new WithdrawnEvent(command.AccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());
        await _eventStore.SaveEventAsync(withdrawEvent);

        Console.WriteLine($"WithdrawCommandHandler: AccountId={command.AccountId}, Amount={command.Amount}");
    }
}