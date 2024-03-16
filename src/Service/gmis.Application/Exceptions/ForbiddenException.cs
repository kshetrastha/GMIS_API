using System.Net;

namespace gmis.Application.Exceptions
{
    public class ForbiddenException : CustomException
    {
        public ForbiddenException() : base(message: "You do not have permissions to access this resource.", statusCode: HttpStatusCode.Forbidden)
        {
        }
    }
}
