using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using Core.Database;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using UserTestingAPI.Application.Services;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Database;
using UserTestingAPI.Database.AutoMigrations;
using UserTestingAPI.Database.Repository;
using UserTestingAPI.Domain.Contracts;

namespace UserTestingAPI.Setup;

public static class DependencyInjection
{
    private static Assembly ApplicationAssembly => Assembly.GetExecutingAssembly();
    public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration appConfiguration)
    {
        services.AddHttpLogging(logging =>
        {
            // // Customize HTTP logging here.
            // logging.LoggingFields = HttpLoggingFields.All;
            // logging.RequestHeaders.Add("sec-ch-ua");
            // logging.ResponseHeaders.Add("my-response-header");
            // logging.MediaTypeOptions.AddText("application/javascript");
            // logging.RequestBodyLogLimit = 4096;
            // logging.ResponseBodyLogLimit = 4096;
        });
        services.AddDbContext<UserTestingDbContext>(opt => opt.UseNpgsql(appConfiguration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IMigrationsManager, MigrationsManager>();
        services.AddValidatorsFromAssembly(ApplicationAssembly);
        services.AddFluentValidationAutoValidation();
        services.AddScoped<UserManager>();
        services.AddScoped<IRepository, Repository>();
        services.AddScoped<IJWTService, JWTService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<ITestCheckerService, TestCheckerService>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appConfiguration["Jwt:Issuer"],
                    ValidAudience = appConfiguration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appConfiguration["Jwt:Key"]))
                };
            });
        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        return services;
    }
}