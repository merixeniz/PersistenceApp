using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.TakeYouForward
{
    public partial class TakeUForward
    {
        public static class Integers
        {
            public static int ReverseNumber(int number)
            {
                int rest, result = 0;

                while (number != 0)
                {
                    rest = number % 10;
                    number /= 10;
                    result = result * 10 + rest;
                }

                return result;
            }
        }
    }

    
}
