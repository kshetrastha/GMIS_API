using System.Net;
using System.Reflection;

namespace gmis.Application.Exceptions
{
    public class NotFoundException : CustomException
    {
        public NotFoundException(string message, int? errorCode = null) : base(message, statusCode: HttpStatusCode.NotFound)
        {
        }
        public NotFoundException(int errorCode, string message) : base(errorCode, message, statusCode: HttpStatusCode.NotFound)
        {
        }
    }
}
