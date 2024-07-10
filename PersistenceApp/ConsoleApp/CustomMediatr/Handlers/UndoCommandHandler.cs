using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CustomMediatr.Handlers
{
    internal class UndoCommandHandler : ICommandHandler<UndoCommand>
    {
        private readonly IEventStore _eventStore;

        public UndoCommandHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task HandleAsync(UndoCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var eventToUndo = await _eventStore.GetEventAsync(command.EventId);
            if (eventToUndo == null)
                throw new ArgumentException($"Event not found: {command.EventId}");

            IEvent reversedEvent = eventToUndo switch
            {
                DepositedEvent deposited => new WithdrawnEvent(deposited.AggregateId, deposited.Amount, DateTimeOffset.UtcNow, Guid.NewGuid()),
                WithdrawnEvent withdrawn => new DepositedEvent(withdrawn.AggregateId, withdrawn.Amount, DateTimeOffset.UtcNow, Guid.NewGuid()),
                TransferredEvent transferred => new TransferredEvent(transferred.AggregateId, transferred.FromAggregateId, transferred.Amount, DateTimeOffset.UtcNow, Guid.NewGuid()),
                _ => throw new InvalidOperationException($"Cannot undo event type: {eventToUndo.GetType().Name}")
            };

            await _eventStore.SaveEventAsync(reversedEvent);
            Console.WriteLine($"UndoCommandHandler: Undone event {command.EventId}");
        }
    }

}
