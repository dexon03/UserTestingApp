using System.Net;
using System.Text;
using FluentValidation;
using IdentityService.Domain.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using UserTestingAPI.Application.Utilities;
using UserTestingAPI.Core.Exceptions;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Constants;
using UserTestingAPI.Domain.Contracts;
using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;
using ValidationException = UserTestingAPI.Core.Exceptions.ValidationException;

namespace UserTestingAPI.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager _userManager;
    private readonly IJWTService _jwtService;
    private readonly IRepository _repository;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public AuthService(UserManager userManager, 
        IJWTService jwtService, 
        IRepository repository,
        IValidator<RegisterRequest> registerValidator,
        IValidator<LoginRequest> loginValidator)
    {
        _userManager = userManager;
        _jwtService = jwtService;
        _repository = repository;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }
    public async Task<TokenResponse> LoginAsync(LoginRequest request,CancellationToken cancellationToken = default)
    {
        await ValidateRequest(request, _loginValidator, cancellationToken);
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (!await IsLoginRequestValid(user, request.Password))
        {
            throw new ExceptionWithStatusCode("Invalid email or password",HttpStatusCode.BadRequest);
        }
        var token = GetNewTokenForUser(user);
        _repository.Update(user);
        await _repository.SaveChangesAsync(cancellationToken);
        return token;
    }


    public async Task<TokenResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        await ValidateRequest(request, _registerValidator, cancellationToken);
        
        var user = await CreateUser(request, cancellationToken);
        var token = GetNewTokenForUser(user);
        await _repository.CreateAsync(user);
        await _repository.SaveChangesAsync(cancellationToken);
        return token;
    }

    public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var userId = _jwtService.ValidateToken(refreshToken);
        if (userId == null)
        {
            throw new ExceptionWithStatusCode("Invalid refresh token", HttpStatusCode.BadRequest);
        }
        
        var user = await _userManager.FindByIdAsync(Guid.Parse(userId));
        var token = GetNewTokenForUser(user);
        _repository.Update(user);
        await _repository.SaveChangesAsync(cancellationToken);
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
    private async Task ValidateRequest<T>(T request, IValidator<T> validator, CancellationToken cancellationToken)
    {
        var result = await validator.ValidateAsync(request, cancellationToken);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
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