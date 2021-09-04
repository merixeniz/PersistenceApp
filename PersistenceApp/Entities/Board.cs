using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Board : BaseEntity, IAggregateRoot
    {
        public Board()
        {
            LastModified = DateTime.Now;
        }
        public string Name { get; set; }
        public string BoardJson { get; set; }
        public DateTime LastModified { get; set; }
        public int Version { get; set; }
        public bool IsDeleted { get; set; }
        public byte[] Thumbnail { get; set; }
        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
