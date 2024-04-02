using System.Collections.Generic;

namespace Application.Algorithms.Searching
{
    public class BinarySearch
    {
        // input has to be sorted!
        public int Search(List<int> input, int target)
        {
            int left = 0;
            int right = input.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (input[mid] == target)
                    return mid;

                if (input[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}
