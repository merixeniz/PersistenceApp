
namespace ConsoleApp.CustomMediatr.Interfaces;

public interface IEventStore
{
    Task SaveEventAsync<T>(T @event) where T : IEvent;
    Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId);
    Task<IEvent?> GetEventAsync(Guid eventId);
}