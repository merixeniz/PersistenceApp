using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Events;

public record TransferredEvent(Guid FromAggregateId, Guid ToAggregateId, decimal Amount, DateTimeOffset Timestamp, Guid EventId) : IEvent
{
    public Guid AggregateId => FromAggregateId;
}

