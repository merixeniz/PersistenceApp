using System.Collections.Generic;

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
