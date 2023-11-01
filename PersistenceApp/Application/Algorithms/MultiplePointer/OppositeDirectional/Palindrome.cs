using System;

namespace Application.Algorithms.MultiplePointer.OppositeDirectional
{
    public class Palindrome
    {
        public bool IsPalindrome(string input)
        {
            if (String.IsNullOrEmpty(input))
                return false;

            var lowered = input.ToLower();

            for (int i = 0; i <= lowered.Length - 1; i++)
            {
                if (lowered[i] != lowered[lowered.Length - 1 - i])
                    return false;
            }

            return true;
        }
    }
}
