using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Domain.Contracts;

public interface IJWTService
{
    string GenerateToken(User user);
    string GenerateRefreshToken(User user);
    string? ValidateToken(string? token);
}