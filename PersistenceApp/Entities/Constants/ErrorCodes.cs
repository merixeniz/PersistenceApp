namespace Entities.Constants
{
    public static class ErrorCodes
    {
        #region NotFound
        public static readonly string UserNotFound = "User Not Found";
        public static readonly string VirtualDeviceNotFound = "Virtual Device Not Found";
        #endregion

        #region BadRequest
        public static readonly string Forbidden = "Not Logged In";
        public static readonly string CommandAlreadyExists = "Command Already Exists";
        public static readonly string InvalidToken = "Invalid Token";
        public static readonly string InvalidCredentials = "Invalid Credentials";

        #endregion

    }
}
