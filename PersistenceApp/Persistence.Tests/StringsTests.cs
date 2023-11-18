using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Algorithms.TakeYouForward;
using Application.Algorithms.Trees;
using FluentAssertions;
using Xunit;

namespace Persistence.Tests
{
    public class StringsTests
    {
        [Theory]
        [InlineData("hello", "llheo")] // General case
        [InlineData("abracadabra", "aaaaabbrrcd")] // Case with repeated characters
        [InlineData("", "")] // Empty string
        [InlineData("a", "a")] // String with a single character
        [InlineData("xyyz", "yyxz")] // Case with repeated characters and sorting
        [InlineData("AaAAaA", "AAAAaa")] // Case with mixed case characters
        public void FrequencySortTest(string input, string result)
        {
            TakeUForward.Strings.FrequencySort(input).Should().Be(result);
        }

        [Theory]
        [InlineData("()()()()()", 1)] // Same level, minimal depth
        [InlineData("(1+2)", 1)] // Single pair
        [InlineData("((()))", 3)] // Nested to the max
        [InlineData("((1+2)*(3-4))", 2)] // Mix of arithmetic and nesting
        [InlineData("(1+(2*3)+((8)/4))+1", 3)] // Example from the original test
        [InlineData("(((()))())", 4)] // Deep nesting with some extra characters
        [InlineData("()()(()(()))", 3)] // Balanced mix of nesting and non-nesting
        [InlineData("()", 1)] // Smallest valid input
        [InlineData("", 0)] // Empty input
        public void MaxDepthParenthesisTest(string input, int expected)
        {
            TakeUForward.Strings.MaxDepth(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("()()()()()", 1)] // Same level, minimal depth
        [InlineData("(1+2)", 1)] // Single pair
        [InlineData("((()))", 3)] // Nested to the max
        [InlineData("((1+2)*(3-4))", 2)] // Mix of arithmetic and nesting
        [InlineData("(1+(2*3)+((8)/4))+1", 3)] // Example from the original test
        [InlineData("(((()))())", 4)] // Deep nesting with some extra characters
        [InlineData("()()(()(()))", 3)] // Balanced mix of nesting and non-nesting
        [InlineData("()", 1)] // Smallest valid input
        [InlineData("", 0)] // Empty input
        public void MaxDepthParenthesisAggregateTest(string input, int expected)
        {
            TakeUForward.Strings.MaxDepthAggregate(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("IX", 9)] // Basic subtraction case
        [InlineData("XC", 90)] // Another subtraction case
        [InlineData("XL", 40)] // Yet another subtraction case
        [InlineData("CD", 400)] // Subtraction with D
        [InlineData("CM", 900)] // Subtraction with M
        [InlineData("VII", 7)] // Basic addition case
        [InlineData("XII", 12)] // Another addition case
        [InlineData("XXI", 21)] // Yet another addition case
        [InlineData("CXLVII", 147)] // Complex case
        [InlineData("MMXXI", 2021)] // Current year
        [InlineData("MMMCMXC", 3990)] // Maximum representation up to 3999
        [InlineData("", 0)] // Empty string
        [InlineData("MMMMCMXCIX", 4999)] // Maximum representation with 4999
        public void RomanToInt(string input, int result)
        {
            TakeUForward.Strings.RomanToInt(input).Should().Be(result);
        }
    }
}
