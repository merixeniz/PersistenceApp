using ConsoleApp.CustomMediatr.Events;

namespace ConsoleApp.CustomMediatr.Aggregate;

public class MessageEventAggregator
{
    public int Id { get; private set; }
    public string? Message { get; private set; }

    public void Apply(MessageCreatedEvent @event)
    {
        Id = @event.Id;
        Message = @event.Message;
    }
}