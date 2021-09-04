﻿using Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VirtualDevice : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}
