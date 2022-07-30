namespace Application.Algorithms.MultiplePointer
{
    public class TwoSum
    {
        // given an array of ints that is already sorted in ascending order, find two numbers such that they add up to a specific target number

        private int[] input = new int[] { 2, 7, 11, 15 };

        public (int index1, int index2) FindTwoNumbers(int[] input, int sumTarget)
        {
            int secondPointer = input.Length - 1;
            var result = (-1, -1);

            for (int i = 0; i < input.Length - 1; i++)
            {
                CheckSum(input, sumTarget, ref secondPointer, ref result, i);

                if (result != (-1, -1))
                    return result;
            }

            return result;
        }
        private static void CheckSum(int[] input, int sumTarget, ref int secondPointer, ref (int, int) result, int i)
        {
            if (input[i] + input[secondPointer] == sumTarget)
            {
                result = (i, secondPointer);
            }
            else if (input[i] + input[secondPointer] > sumTarget)
            {
                secondPointer--;

                if (secondPointer >= 0)
                    CheckSum(input, sumTarget, ref secondPointer, ref result, i);
            }
        }


        public (int index1, int index2) TwoSumWhile(int[] input, int sumTarget)
        {
            int leftPointer = 0;
            int rightPointer = input.Length - 1;
            var result = (-1, -1);

            while (leftPointer < rightPointer)
            {
                if (input[leftPointer] + input[rightPointer] == sumTarget)
                {
                    result = (leftPointer, rightPointer);
                    break;
                }
                else if (input[leftPointer] + input[rightPointer] > sumTarget)
                    rightPointer--;

                else
                    leftPointer++;
            }

            return result;
        }
    }
}
