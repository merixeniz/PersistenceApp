using System.Collections.Generic;
using System.Linq;

namespace Application.Algorithms.MultiplePointer.EquiDirectional
{
    // given an array of integers n and a prositive number k, find the maximum sum of any contiguous subarray of size k
    public class MaxSumOfSubarray
    {
        public int FindMaxSumOfSubArrayOfSizeK(int[] input, int k)
        {
            int leftPointer = 0;
            int rightPointer = 0;
            int sum = input[leftPointer];
            int windowSize = 1;

            var sums = new List<int>();
            sums.Add(sum);

            while (rightPointer != input.Length - 1)
            {
                if (windowSize < k)
                {
                    rightPointer++;
                    windowSize++;
                    sum += input[rightPointer];
                    sums.Add(sum);
                }
                else
                {
                    sum -= input[leftPointer];
                    leftPointer++;
                    rightPointer++;
                    sum += input[rightPointer];
                    sums.Add(sum);
                }
            }
            return sums.Max();
        }
    }
}
