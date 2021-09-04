﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class GetBoardsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastModified { get; set; }
        public int Version { get; set; }
    }
}
