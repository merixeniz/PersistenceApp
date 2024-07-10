using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers;

internal class DepositCommandHandler : ICommandHandler<DepositCommand>
{
    private readonly IEventStore _eventStore;

    public DepositCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task HandleAsync(DepositCommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var depositEvent = new DepositedEvent(command.AccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());
        await _eventStore.SaveEventAsync(depositEvent);

        Console.WriteLine($"DepositCommandHandler: AccountId={command.AccountId}, Amount={command.Amount}");
    }
}