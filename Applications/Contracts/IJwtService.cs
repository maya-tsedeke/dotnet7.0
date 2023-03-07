using System.Security.Claims;
using Applications.Models.Jwt;
using Domain.Entities.User;

namespace Applications.Contracts;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
    Task<AccessToken> RefreshToken(string refreshTokenId);
}