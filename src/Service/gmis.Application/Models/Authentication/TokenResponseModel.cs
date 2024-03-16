namespace gmis.Application.Models.Authentication
{
    public record TokenResponseModel(string Token, string RefreshToken, 
        DateTime RefreshTokenExpiryTime, DateTime TokenExpiryTime, string UserId, string UserName);
}
