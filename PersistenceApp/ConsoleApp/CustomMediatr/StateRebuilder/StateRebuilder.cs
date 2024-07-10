using ConsoleApp.CustomMediatr.Aggregate;
using ConsoleApp.CustomMediatr.Entities;
using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;
using System.Linq;

namespace ConsoleApp.CustomMediatr.StateRebuilder;

public class StateRebuilder
{
    private readonly IEventStore _eventStore;
    private readonly IBankAccountRepository _repository;

    public StateRebuilder(IEventStore eventStore, IBankAccountRepository repository)
    {
        _eventStore = eventStore;
        _repository = repository;
    }

    public async Task<BankAccount> RebuildStateAsync(Guid aggregateId)
    {
        var events = (await _eventStore.GetEventsAsync(aggregateId)).ToArray();
        var bankAccount = await _repository.GetByIdAsync(aggregateId);
        var aggregate = new MessageEventAggregator();

        foreach (var @event in events)
        {
            switch (@event)
            {
                case DepositedEvent depositedEvent:
                    bankAccount.Apply(depositedEvent);
                    break;
                case WithdrawnEvent withdrawnEvent:
                    bankAccount.Apply(withdrawnEvent);
                    break;
                case TransferredEvent transferredEvent:
                    var fromAccount = await _repository.GetByIdAsync(transferredEvent.FromAggregateId);
                    var toAccount = await _repository.GetByIdAsync(transferredEvent.ToAggregateId);

                    fromAccount.Apply(transferredEvent);
                    toAccount.Apply(transferredEvent);
                    break;
                case ReversedEvent reversedEvent:
                    bankAccount.Apply(reversedEvent);
                    break;

                case MessageCreatedEvent messageCreatedEvent:
                    aggregate.Apply(messageCreatedEvent);
                    break;
            }
        }

        return bankAccount;
    }


}