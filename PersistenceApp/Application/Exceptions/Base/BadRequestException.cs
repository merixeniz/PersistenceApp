using System;

namespace Application.Exeptions
{
    public class BadRequestException : Exception
    {
        public string Title { get; }
        public object ResponseData { get; set; }

        public BadRequestException(string message) : base(message)
        {
            Title = "An error occured";
        }

        public BadRequestException(string title, string message) : base(message)
        {
            Title = title;
        }
    }
}
