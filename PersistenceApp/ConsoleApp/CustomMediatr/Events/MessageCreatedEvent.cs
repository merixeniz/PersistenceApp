using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Events;

public record MessageCreatedEvent(Guid AggregateId, int Id, string Message, DateTimeOffset Timestamp, Guid EventId) : IEvent;