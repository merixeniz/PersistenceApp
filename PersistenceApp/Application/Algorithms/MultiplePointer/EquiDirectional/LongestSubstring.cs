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

        public string FindLongestSubstringWithoutCharRepetitionGpt(string input)
        {
            if (input == null)
                return null;

            input = input.ToLower(); // case insensitive

            int leftPointer = 0;
            int maxLength = 0;
            int startIndexOfMax = 0;
            var charIndexMap = new Dictionary<char, int>();

            for (int rightPointer = 0; rightPointer < input.Length; rightPointer++)
            {
                char currentChar = input[rightPointer];

                if (charIndexMap.ContainsKey(currentChar) && charIndexMap[currentChar] >= leftPointer)
                {
                    leftPointer = charIndexMap[currentChar] + 1;
                }

                charIndexMap[currentChar] = rightPointer;

                int currentLength = rightPointer - leftPointer + 1;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    startIndexOfMax = leftPointer;
                }
            }

            return input.Substring(startIndexOfMax, maxLength);
        }
        public int LengthOfLongestSubstring(string s)
        {
            int result = 0;
            var tmpResult = new List<char>();

            for (int start = 0; start <= s.Length - 1; start++)
            {
                tmpResult.Clear();
                tmpResult.Add(s[start]);
                for (int end = 0; end <= s.Length - 1; end++)
                {
                    if (end <= start) continue;

                    if (!tmpResult.Contains(s[end]))
                    {
                        tmpResult.Add(s[end]);

                        if (tmpResult.Count > result)
                            result = tmpResult.Count;
                    }
                    else
                    {
                        break;
                    }
                }
                if (tmpResult.Count > result)
                    result = tmpResult.Count;
            }
            return result;
        }
    }
}
