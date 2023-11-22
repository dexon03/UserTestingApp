using IdentityService.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTestingAPI.Domain.Contracts;
using UserTestingAPI.Domain.Dtos;

namespace UserTestingAPI.Controllers;

[AllowAnonymous]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request,CancellationToken cancellationToken)
    {
        var response = await _authService.LoginAsync(request, cancellationToken);
        return Ok(response);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request,CancellationToken cancellationToken)
    {
        var response = await _authService.RegisterAsync(request, cancellationToken);
        return Ok(response);
    }
}