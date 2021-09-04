namespace Entities.Base
{
    public class ResponseStatus
    {
        public static class Types
        {
            public const string Success = "success";
            public const string Error = "error";
        }

        public string Type { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
