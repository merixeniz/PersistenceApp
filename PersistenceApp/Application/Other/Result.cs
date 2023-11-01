namespace Application.Other
{
    public class Result<T>
    {
        public T Data { get; private set; }
        public bool Succeed { get; private set; }
        public string Message { get; private set; }
        public Result(T data, bool succeed, string message)
        {
            Data = data;
            Succeed = succeed;
            Message = message;
        }

        public static Result<T> Success(T data, string message = null)
        {
            return new Result<T>(data, succeed: true, message);
        }

        public static Result<T> Failure(T data, string message = null)
        {
            return new Result<T>(data, succeed: false, message);
        }


    }
}
