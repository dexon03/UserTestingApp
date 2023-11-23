using System.Net;
using IdentityService.Domain.Dto;
using UserTestingAPI.Application.Utilities;
using UserTestingAPI.Core.Exceptions;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Contracts;
using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager _userManager;
    private readonly IJWTService _jwtService;
    private readonly IRepository _repository;

    public AuthService(UserManager userManager, 
        IJWTService jwtService, 
        IRepository repository)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _repository = repository;
    }
    public async Task<TokenResponse> LoginAsync(LoginRequest request,CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (!await IsLoginRequestValid(user, request.Password))
        {
            throw new ExceptionWithStatusCode("Invalid email or password",HttpStatusCode.BadRequest);
        }
        var token = GetNewTokenForUser(user);
        return token;
    }

    public async Task<TokenResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var user = await CreateUser(request, cancellationToken);
        await _repository.CreateAsync(user);
        await _repository.SaveChangesAsync(cancellationToken);
        var token = GetNewTokenForUser(user);
        return token;
    }

    public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default)
    {
        var userId = _jwtService.ValidateToken(request.RefreshToken);
        if (userId == null)
        {
            throw new ExceptionWithStatusCode("Invalid refresh token", HttpStatusCode.BadRequest);
        }
        
        var user = await _userManager.FindByIdAsync(Guid.Parse(userId));
        var token = GetNewTokenForUser(user);
        return token;
    }

    private TokenResponse GetNewTokenForUser(User user)
    {
        var accessToken = _jwtService.GenerateToken(user);
        var newRefreshToken = _jwtService.GenerateRefreshToken(user);
        return new TokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken,
            UserId = user.Id
        };
    }
    
    private async Task<User> CreateUser(RegisterRequest request, CancellationToken cancellationToken)
    {
        var passwordSalt = PasswordUtility.CreatePasswordSalt();
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordSalt = passwordSalt,
            PasswordHash = PasswordUtility.GetHashedPassword(request.Password, passwordSalt),
        };
        return user;
    }
    
    private async Task<bool> IsLoginRequestValid(User? user, string password)
    {
        if (user == null)
        {
            return false;
        }
        return await _userManager.CheckPasswordAsync(user, password);
    }
}