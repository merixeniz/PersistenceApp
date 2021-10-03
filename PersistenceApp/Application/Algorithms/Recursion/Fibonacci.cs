using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.Recursion
{
    public class Fibonacci
    {
        public int FibonacciNumber(int n)
        {
            if (n < 2)
                return n;

            return FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
        }
    }
}
