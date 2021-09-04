using Entities.Base;

namespace Entities
{
    public class VirtualDevice : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
