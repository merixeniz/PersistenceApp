using System.Collections.Generic;
using System.Linq;

namespace Application.Algorithms.MultiplePointer
{
    public class LongestSubstring
    {
        public string FindLongestSubstringWithoutCharRepetition(string input)
        {
            if (input == null)
                return null;

            input = input.ToLower(); // case insensitive

            int leftPointer = 0;
            int rightPointer = 0;
            string subString = input[leftPointer].ToString();

            var subStrings = new List<string>(); // this takes a lot of memory for every substring

            while (rightPointer < input.Length - 1)
            {
                rightPointer++;

                if (subString.Contains(input[rightPointer].ToString()))
                {
                    subStrings.Add(subString);
                    leftPointer = rightPointer;
                    subString = input[leftPointer].ToString();
                }
                else
                {
                    subString += input[rightPointer];
                }

                subStrings.Add(subString);
            }

            return subStrings.OrderByDescending(x => x.Length).First();
        }
    }
}
