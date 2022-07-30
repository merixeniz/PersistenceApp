using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ServiceBus;
using MassTransit;

namespace Application.Consumers
{
    public class MessageConsumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            await Task.Run(() => Console.WriteLine($"Scanner-Ping, Msg received: {context.Message.Body}"));
        }
    }
}
