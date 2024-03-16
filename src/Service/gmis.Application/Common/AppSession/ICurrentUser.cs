using System.Security.Claims;

namespace gmis.Application.Common.AppSession
{
    public interface ICurrentUser
    {
        string? Name { get; }
        Guid GetUserId();
        string? GetUserEmail();
        bool IsAuthenticated();
        IEnumerable<Claim>? GetUserClaims();
    }
}
