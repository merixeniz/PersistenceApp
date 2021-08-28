using System.Collections.Generic;

namespace Application.Algorithms
{
    public class ParenthesisProblem
    {
        private readonly Stack<char> _stack;
        public ParenthesisProblem()
        {
            _stack = new Stack<char>();
        }
        public bool CheckParenthesis(string brackets)
        {
            char sign;

            for (int i = 0; i < brackets.Length; i++)
            {
                switch (brackets[i])
                {
                    case '(':
                        _stack.Push(brackets[i]);
                        break;

                    case '{':
                        _stack.Push(brackets[i]);
                        break;

                    case '[':
                        _stack.Push(brackets[i]);
                        break;

                    case ')':
                        sign = _stack.Pop();
                        
                        if (sign != '(')
                            return false;
                        break;

                    case '}':
                        sign = _stack.Pop();

                        if (sign != '{')
                            return false;
                        break;

                    case ']':
                        sign = _stack.Pop();

                        if (sign != '[')
                            return false; 
                        break;

                    default:
                        return false;
                }
            }

            if (_stack.Count > 0)
                return false;

            return true;
        }
    }
}
