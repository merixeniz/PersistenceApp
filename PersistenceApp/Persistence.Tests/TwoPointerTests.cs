using Application.Algorithms.MultiplePointer;
using Application.Algorithms.MultiplePointer.EquiDirectional;
using Application.Algorithms.MultiplePointer.OppositeDirectional;
using FluentAssertions;
using Xunit;

namespace Persistence.Tests
{
    public class TwoPointerTests
    {
        [Fact]
        public void TwoSum_Example1()
        {
            int[] input = new int[] { 2, 7, 11, 15 };
            int target1 = 9;
            int target2 = 18;


            var twoSum = new TwoSum();
            var result1 = twoSum.FindTwoNumbers(input, target1);
            var result2 = twoSum.FindTwoNumbers(input, target2);

            result1.Should().Be((0, 1));
            result2.Should().Be((1, 2));
        }

        [Fact]
        public void TwoSum_Example2()
        {
            int[] input = new int[] { -3, 2, 3, 3, 6, 8, 15 };
            int target = 6;

            var twoSum = new TwoSum();
            var result = twoSum.FindTwoNumbers(input, target);

            result.Should().Be((2, 3));
        }

        [Fact]
        public void TwoSumWhile_Example1()
        {
            int[] input = new int[] { 2, 7, 11, 15 };
            int target1 = 9;
            int target2 = 18;


            var twoSum = new TwoSum();
            var result1 = twoSum.TwoSumWhile(input, target1);
            var result2 = twoSum.TwoSumWhile(input, target2);

            result1.Should().Be((0, 1));
            result2.Should().Be((1, 2));
        }

        [Fact]
        public void TwoSumWhile_Example2()
        {
            int[] input = new int[] { -3, 2, 3, 3, 6, 8, 15 };
            int target = 6;

            var twoSum = new TwoSum();
            var result = twoSum.TwoSumWhile(input, target);

            result.Should().Be((2, 3));
        }


        [Fact]
        public void FindMaxSubOfSubarrayOfSizeK_Example1()
        {
            var sut = new MaxSumOfSubarray();
            int[] input = new int[] { 2, 1, 5, 1, 3, 2 };
            int k = 3;

            sut.FindMaxSumOfSubArrayOfSizeK(input, k).Should().Be(9);
        }

        [Fact]
        public void FindMaxSubOfSubarrayOfSizeK_Example2()
        {
            var sut = new MaxSumOfSubarray();
            int[] input = new int[] { 1, 9, -1, -2, 7, 3, -1, 2};
            int k = 4;

            sut.FindMaxSumOfSubArrayOfSizeK(input, k).Should().Be(13);
        }

        [Fact]
        public void LongestSubString_Example1()
        {
            var sut = new LongestSubstring();
            string input = "abcdefaaabcdefgh";

            sut.FindLongestSubstringWithoutCharRepetition(input).Should().Be("abcdefgh");
        }

        [Fact]
        public void LongestSubString_Example2()
        {
            var sut = new LongestSubstring();
            string input = "abcdAabcdefghijkAbvzAssA";

            sut.FindLongestSubstringWithoutCharRepetition(input).Should().Be("abcdefghijk");
        }

        [Fact]
        public void Palindrome_Example1()
        {
            var sut = new Palindrome();

            string input = "kajak";
            string input2 = "aaabb";
            string input3 = "AbcddCba";

            sut.IsPalindrome(input).Should().Be(true);
            sut.IsPalindrome(input2).Should().Be(false);
            sut.IsPalindrome(input3).Should().Be(true);

        }
    }
}
