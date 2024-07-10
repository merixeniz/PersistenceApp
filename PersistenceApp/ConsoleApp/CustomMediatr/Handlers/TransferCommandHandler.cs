using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers;

internal class TransferCommandHandler : ICommandHandler<TransferCommand>
{
    private readonly IEventStore _eventStore;

    public TransferCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task HandleAsync(TransferCommand command)
    {
        if (command == null)
            throw new ArgumentNullException(nameof(command));

        var transferEvent = new TransferredEvent(command.FromAccountId, command.ToAccountId, command.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());
        await _eventStore.SaveEventAsync(transferEvent);

        Console.WriteLine($"TransferCommandHandler: FromAccountId={command.FromAccountId}, ToAccountId={command.ToAccountId}, Amount={command.Amount}");
    }
}