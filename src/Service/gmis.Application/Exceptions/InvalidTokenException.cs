using System.Net;

namespace gmis.Application.Exceptions
{
    public class InvalidTokenException : CustomException
    {
        public InvalidTokenException(int errorCode, string message) : base(errorCode, message, HttpStatusCode.ProxyAuthenticationRequired)
        {
        }
    }
}
