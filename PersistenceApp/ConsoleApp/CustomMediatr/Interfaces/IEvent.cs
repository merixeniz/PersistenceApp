namespace ConsoleApp.CustomMediatr.Interfaces;

public interface IEvent
{
    Guid AggregateId { get; }
    Guid EventId { get; }
    DateTimeOffset Timestamp { get; }
}