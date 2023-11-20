using System.Net;
using Newtonsoft.Json;

namespace UserTestingAPI.Core.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string ContentType = "application/json";
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next.Invoke(httpContext);
        }
        catch (Exception exception)
        {
            await HandleException(httpContext, exception);
        }
    }

    private Task HandleException(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = ContentType;
        switch (exception)
        {
            case UnauthorizedAccessException:
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                break;
            case ExceptionWithStatusCode exceptionWithStatusCode:
                response.StatusCode = (int)exceptionWithStatusCode.StatusCode;
                break; 
            case ValidationException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        
        _logger.LogError(exception, exception.Message);
        var result = JsonConvert.SerializeObject(new { message = exception?.Message });
        return response.WriteAsync(result);
        
    }
}