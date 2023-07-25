using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Other
{
    [Flags]
    public enum FlagEnum
    {
        None = 0,
        Option1 = 1,
        Option2 = 2,
        Option3 = 4,
        Option4 = 8
    }
}
