using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.RandomStuff
{
    public class RandomProblems
    {
        public int Reverse(int x)
        {
            if (x == int.MaxValue || x == int.MinValue) return 0;

            var tmp = Math.Abs(x).ToString().ToCharArray().Reverse().Select(x => x).ToArray();

            if (!int.TryParse(tmp, out int result)) return 0;

            if (x < 0)
                result *= -1;

            return result;
        }

        public int ReverseGpt(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int digit = x % 10;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7))
                    return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8))
                    return 0;
                result = result * 10 + digit;
                x /= 10;
            }
            return result;
        }

    }
}
