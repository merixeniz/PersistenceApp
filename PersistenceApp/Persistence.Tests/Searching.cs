using Application.Algorithms.Searching;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Persistence.Tests
{
    public class Searching
    {

        [Fact]
        public void BinarySearch()
        {
            var sut = new BinarySearch();
            var input = new List<int> { -5, -4, -3, -2, 0, 1, 2, 3, 4, 5 };

            sut.Search(input, 2).Should().Be(6);
            sut.Search(input, -5).Should().Be(0);
            sut.Search(input, 0).Should().Be(4);
        }
    }
}
