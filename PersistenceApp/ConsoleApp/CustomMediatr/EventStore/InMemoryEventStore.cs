using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.EventStore;

public class InMemoryEventStore : IEventStore
{
    private readonly List<IEvent> _events = new List<IEvent>();

    public async Task SaveEventAsync<T>(T @event) where T : IEvent
    {
        _events.Add(@event);
        await Task.CompletedTask;
    }

    public async Task<IEnumerable<IEvent>> GetEventsAsync(Guid aggregateId)
    {
        return await Task.FromResult(_events.Where(e => e.AggregateId == aggregateId));
    }

    public async Task<IEvent?> GetEventAsync(Guid eventId)
    {
        return await Task.FromResult(_events.FirstOrDefault(e => e.EventId == eventId));
    }
}