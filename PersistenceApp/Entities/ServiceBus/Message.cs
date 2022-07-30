using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ServiceBus
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
	}
}
