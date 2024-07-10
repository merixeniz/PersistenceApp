using ConsoleApp.CustomMediatr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CustomMediatr.Events
{
    public record ReversedEvent(Guid AggregateId, decimal Amount, DateTimeOffset Timestamp, Guid EventId) : IEvent;
}
