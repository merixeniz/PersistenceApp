using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.Searching
{
    public class BinarySearch
    {
        // input has to be sorted!
        public int Search(List<int> input, int target)
        {
            var midPointer = (input.Count - 1) / 2;

            while (input[midPointer] != target)
            {
                if (input[midPointer] > target)
                    midPointer--;

                if (input[midPointer] < target)
                    midPointer++;
            }

            return midPointer;
        }
    }
}
