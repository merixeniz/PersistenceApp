using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Events;

public record DepositedEvent(Guid AggregateId, decimal Amount, DateTimeOffset Timestamp, Guid EventId) : IEvent;