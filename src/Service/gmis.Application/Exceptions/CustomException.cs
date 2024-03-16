using System.Net;

namespace gmis.Application.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public int ErrorCode { get; }
        public CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorCode = (int)statusCode;
            StatusCode = statusCode;
        }
        public CustomException(int errorCode, string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
             : base(message)
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }
    }
}
