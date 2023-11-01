using System;

namespace Application.Exeptions
{
    public class NotFoundException : Exception
    {
        public string Title { get; }

        public NotFoundException(string message) : base(message)
        {
            Title = "404 Not Found";
        }

        public NotFoundException(string title, string message) : base(message)
        {
            Title = title;
        }
    }
}
