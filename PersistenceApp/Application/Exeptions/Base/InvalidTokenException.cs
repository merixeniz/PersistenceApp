using Entities.Constants;
using System;

namespace Application.Exeptions
{
    public class InvalidTokenException : Exception
    {
        public string Title { get; set; }

        public InvalidTokenException()
        {
            Title = ErrorCodes.InvalidToken;
        }

        public InvalidTokenException(string title)
        {
            Title = title;
        }
    }
}
