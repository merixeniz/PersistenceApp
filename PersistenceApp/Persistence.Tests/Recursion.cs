using Application.Algorithms.Recursion;
using FluentAssertions;
using Xunit;

namespace Persistence.Tests;
public class Recursion
{
    [Fact]
    public void Fibonacci()
    {
        var fibo = new Fibonacci();

        fibo.FibonacciNumber(0).Should().Be(0);
        fibo.FibonacciNumber(1).Should().Be(1);
        fibo.FibonacciNumber(2).Should().Be(1);
        fibo.FibonacciNumber(5).Should().Be(5);
        fibo.FibonacciNumber(6).Should().Be(8);
        fibo.FibonacciNumber(7).Should().Be(13);
        fibo.FibonacciNumber(8).Should().Be(21);
    }
}