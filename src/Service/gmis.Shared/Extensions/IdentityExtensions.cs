using System.Security.Claims;

namespace gmis.Shared.Extensions
{
    public static class IdentityExtensions
    {
        public static string? GetUserId(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ClaimTypes.NameIdentifier);

        public static string? GetEmail(this ClaimsPrincipal principal)
            => principal.FindFirstValue(ClaimTypes.Email);

        private static string? FindFirstValue(this ClaimsPrincipal principal, string claimType) =>
            principal is null
            ? throw new ArgumentNullException(nameof(principal))
            : principal.FindFirst(claimType)?.Value;
    }
}
