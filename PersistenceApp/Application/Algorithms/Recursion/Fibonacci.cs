namespace Application.Algorithms.Recursion
{
    public class Fibonacci
    {
        public int FibonacciNumber(int n)
        {
            if (n < 2)
                return n;

            return FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
        }
    }
}
