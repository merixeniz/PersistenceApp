using Application.Algorithms.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Algorithms.TakeYouForward
{
    public static partial class TakeUForward
    {
        public static class Arrays
        {
            public static string LongestCommonPrefix(string[] strs)
            {
                var shortest = strs.OrderBy(x => x).First();

                for (int i = 0; i < shortest.Length; i++)
                {
                    if (strs.Any(word => word[i] != shortest[i])) return shortest[..i];
                }

                return shortest;
            }
            public static bool WordBreak(string s, IList<string> wordDict)
            {
                var trie = new Trie();
                var index = 0;

                foreach (var word in wordDict)
                {
                    trie.Insert(word);
                }

                for (int i = 0; i < s.Length; i++)
                {
                    if (!trie.Search(s[..i])) index = i;
                }

                return false;

            }
            public static int[] ReverseArray(int[] input)
            {
                if (input.Length == 0) return Array.Empty<int>();

                var output = new int[input.Length];

                for (int i = 0; i < input.Length; i++)
                {
                    output[output.Length - 1 - i] = input[i];
                }

                return output;
            }
            public static int[] ZerosToEnd(int[] arr)
            {
                // https://takeuforward.org/data-structure/move-all-zeros-to-the-end-of-the-array/

                if (arr.Length == 0) return Array.Empty<int>();

                var output = new int[arr.Length];
                // 1st
                var filtered = arr.Where(x => x != 0).ToArray();
                Array.Copy(filtered, output, filtered.Length);
                return output;

                //2nd 
                int outputPointer = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != 0)
                    {
                        output[outputPointer] = arr[i];
                        outputPointer++;
                    }
                }
                return output;
            }
            public static int GetSingleElement(int[] arr)
            {
                // var input = new int[] { 4, 1, 2, 1, 2 };
                int xor = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    xor = xor ^ arr[i];
                }

                return xor;
            }
            public static int[] LongestSubarrayWithGivenSumPositives(int[] arr, int sum)
            {
                //input: sum = 5, array[] = { 2, 3, 5, 1, 9 }
                if (arr.Length == 0) return Array.Empty<int>();

                int left, right = 0;
                var results = new List<int[]>();

                for (int i = 0; i < arr.Length; i++)
                {
                    left = i;
                    right = i + 1;
                    int tmpSum = arr[left];

                    while (tmpSum < sum && right < arr.Length)
                    {
                        tmpSum += arr[right];
                        right++;
                    }

                    if (tmpSum == sum)
                        results.Add(arr[left..right]);
                }

                return results.MinBy(x => x.Length) ?? Array.Empty<int>();
            }
        }

        

        // LAST: https://takeuforward.org/data-structure/longest-subarray-with-given-sum-k/
    }
}
