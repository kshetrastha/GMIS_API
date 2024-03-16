using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using gmis.Application.Exceptions;
using System.Net;
using Microsoft.Extensions.Logging;
using gmis.Application.Common.Model;

namespace gmis.Infrastructure.Middlewares.ExceptionMiddlewareSetup
{
    internal class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;
        public ExceptionMiddleware
        (ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var errorResult = exception switch
                {
                    UnauthorizedException unauthorizedException => ErrorResult.HandleUnauthorizedException(unauthorizedException),
                    ForbiddenException forbiddenException => ErrorResult.HandleForbiddenException(forbiddenException),
                    NotFoundException notFoundException => ErrorResult.HandleNotFoundException(notFoundException),
                    CustomException customException => ErrorResult.HandleCustomException(customException),
                    _ => ErrorResult.HandleDefaultException(exception),
                };

                var response = context.Response;
                response.ContentType = "application/json";

                logger.LogError(errorResult.ToString());
                await response.WriteAsync(JsonConvert.SerializeObject(new ResponseModel<ErrorResult>(false,null,errorResult)));
            }
        }

    }
}
