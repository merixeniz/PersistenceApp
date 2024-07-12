using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Entities;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers
{
    internal class UndoCommandHandler : ICommandHandler<UndoCommand>
    {
        private readonly IEventStore _eventStore;
        private readonly IBankAccountRepository _bankAccountRepository;

        public UndoCommandHandler(IEventStore eventStore, IBankAccountRepository bankAccountRepository)
        {
            _eventStore = eventStore;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task HandleAsync(UndoCommand command)
        {
            if (command == null)
                return;

            var eventToUndo = await _eventStore.GetEventAsync(command.EventId);
            if (eventToUndo == null)
                return;

            BankAccount bankAccount;
            BankAccount fromAccount;
            BankAccount toAccount;
            IEvent reversedEvent;

            switch (eventToUndo)
            {
                case DepositedEvent deposited:
                    var withdrawnEvent = new WithdrawnEvent(deposited.AggregateId, deposited.Amount, DateTimeOffset.UtcNow,
                        Guid.NewGuid());
                    bankAccount = await _bankAccountRepository.GetByIdAsync(deposited.AggregateId);
                    bankAccount.Apply(withdrawnEvent);
                    reversedEvent = withdrawnEvent;
                    break;
                case WithdrawnEvent withdrawn:
                    var depositedEvent = new DepositedEvent(withdrawn.AggregateId, withdrawn.Amount, DateTimeOffset.UtcNow,
                        Guid.NewGuid());
                    bankAccount = await _bankAccountRepository.GetByIdAsync(withdrawn.AggregateId);
                    bankAccount.Apply(depositedEvent);
                    reversedEvent = depositedEvent;
                    break;
                case TransferredEvent transferred:
                    var transferredEvent = new TransferredEvent(transferred.ToAggregateId, transferred.FromAggregateId,
                        transferred.Amount, DateTimeOffset.UtcNow, Guid.NewGuid());

                    fromAccount = await _bankAccountRepository.GetByIdAsync(transferred.ToAggregateId);
                    toAccount = await _bankAccountRepository.GetByIdAsync(transferred.FromAggregateId);

                    var withdrawSucceeded = fromAccount.Apply(transferredEvent);

                    if (!withdrawSucceeded)
                        return;

                    toAccount.Apply(transferredEvent);

                    reversedEvent = transferredEvent;
                    break;
                default:
                    throw new InvalidOperationException($"Cannot undo event type: {eventToUndo.GetType().Name}");
            }

            await _eventStore.SaveEventAsync(reversedEvent);
            Console.WriteLine($"UndoCommandHandler: Undone event {command.EventId}");
        }
    }

}
