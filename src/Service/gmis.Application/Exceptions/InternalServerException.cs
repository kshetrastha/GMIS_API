using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Exceptions
{
    public class InternalServerException : CustomException
    {
        public InternalServerException(int errorCode, string message)
            : base(errorCode, message, HttpStatusCode.InternalServerError)
        {
        }
    }
}
