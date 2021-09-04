using System;

namespace Application.Exeptions
{
    public class ForbiddenException : Exception
    {
        public string Title { get; }

        public ForbiddenException(string message) : base(message)
        {
            Title = "Forbidden";
        }

        public ForbiddenException(string title, string message) : base(message)
        {
            Title = title;
        }
    }
}
