using System.Reflection.Metadata.Ecma335;
using Application.Algorithms.Trees;
using Microsoft.Azure.Amqp.Framing;
using Application.Algorithms.TakeYouForward;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strs = new[] { "abc", "anno" };
            TakeUForward.Arrays.LongestCommonPrefix(strs);

            var s = "leetcode";
            var wordDict = new[] { "leet", "code" };
            TakeUForward.Arrays.WordBreak(s, wordDict);

            var reversed = TakeUForward.Arrays.ReverseArray(new[] { 1, 2, 3, 4 });

            string str = "abcdefg";
            var result = str[2..4];

            var zerosToEndInput = new[] { 1, 0, 2, 3, 0, 4, 0, 1 };
            TakeUForward.Arrays.ZerosToEnd(zerosToEndInput);


            var getSingleElementInput = new[] { 4, 1, 2, 1, 2 };
            TakeUForward.Arrays.GetSingleElement(getSingleElementInput);

            var array = new[] { 2, 3, 5, 1, 9 };
            TakeUForward.Arrays.LongestSubarrayWithGivenSumPositives(array, 10);

            var maxSubArray = new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            TakeUForward.Arrays.MaxSubArraySum(maxSubArray);

            var stocks = new[] { 7, 1, 5, 3, 6, 4 };
            TakeUForward.Arrays.StockBuyAndSell(stocks);

            Console.WriteLine("Hello, World!");
        }


    }
}