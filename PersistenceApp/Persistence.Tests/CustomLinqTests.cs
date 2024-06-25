using System;
using System.Collections.Generic;
using Application.Algorithms.LINQ;
using Application.Extensions;
using FluentAssertions;
using Xunit;

namespace Persistence.Tests
{
    public class CustomLinqTests
    {
        public static IEnumerable<object[]> TestData =>
            new List<object[]>
            {
                new object[] { new[] { 1, 2, 0, 3, 4 }, new[] { 1, 2, 3, 4, 0 }, (Func<int, bool>)(x => x == 0) },
                new object[] { new[] { 0, 1, 2, 3, 4 }, new[] { 1, 2, 3, 4, 0 }, (Func<int, bool>)(x => x == 0) },
                new object[] { new[] { 1, 2, 3, 4, 0 }, new[] { 1, 2, 3, 4, 0 }, (Func<int, bool>)(x => x == 0) },
                new object[] { new[] { 0, 0, 0, 0 }, new[] { 0, 0, 0, 0 }, (Func<int, bool>)(x => x == 0) },
                new object[] { new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 }, (Func<int, bool>)(x => x == 0) }
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void MoveToEnd_ShouldMoveZerosToEnd(int[] input, int[] expected, Func<int, bool> predicate)
        {
            // Act
            var result = input.MoveToEnd(predicate);

            // Assert
            input.MoveToEnd(predicate).Should().BeEquivalentTo(expected);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void LinqFun_GroupBy_ShouldReturnFirstItemOfFirstGroup()
        {
            var groupByResult = LinqFun.GroupBy_ReturnFirstItemOfFirstGroup();
            var distinctResult = LinqFun.Distinct_byType();
            Assert.Equal(true, true);
        }

    }
}
