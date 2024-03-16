using Microsoft.AspNetCore.WebUtilities;
using System.Net;

namespace gmis.Application.Exceptions
{
    public class ErrorResult
    {
        public string? Title { get; set; }
        public string? Detail { get; set; }
        public List<string>? Errors { get; private set; }
        public int? Status { get; set; }
        public int ErrorCode { get; set; }

        public static ErrorResult HandleDefaultException(Exception exception)
        {
            var errorResult = new ErrorResult()
            {
                Title = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.InternalServerError),
                Detail = exception.Message.Trim(),
                Status = (int)HttpStatusCode.InternalServerError,
                ErrorCode = 500
            };
            return errorResult;
        }

        public static ErrorResult HandleNotFoundException(NotFoundException exception)
        {
            var errorResult = new ErrorResult()
            {
                Title = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.NotFound),
                Detail = exception.Message.Trim(),
                Status = (int)HttpStatusCode.NotFound,
                ErrorCode = exception.ErrorCode,
            };
            return errorResult;
        }

        public static ErrorResult HandleCustomException(CustomException exception)
        {
            var errorResult = new ErrorResult()
            {
                Title = ReasonPhrases.GetReasonPhrase((int)exception.StatusCode),
                Detail = exception.Message.Trim(),
                Status = (int)exception.StatusCode,
                ErrorCode = exception.ErrorCode,
            };
            return errorResult;
        }

        public static ErrorResult HandleUnauthorizedException(UnauthorizedException unauthorizedException)
        {
            return new ErrorResult()
            {
                Title = string.IsNullOrEmpty(unauthorizedException.Error) ? ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.Unauthorized) : unauthorizedException.Error,
                Detail = string.IsNullOrEmpty(unauthorizedException.Description) ? unauthorizedException.Message.Trim() : unauthorizedException.Description,
                Status = (int)HttpStatusCode.Unauthorized,
                ErrorCode = unauthorizedException.ErrorCode,
            };
        }
        public static ErrorResult HandleForbiddenException(ForbiddenException forbiddenException)
        {
            return new ErrorResult()
            {
                Title = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.Forbidden),
                Detail = forbiddenException.Message.Trim(),
                Status = ((int)HttpStatusCode.Forbidden),
                ErrorCode = forbiddenException.ErrorCode,
            };
        }
    }
}
