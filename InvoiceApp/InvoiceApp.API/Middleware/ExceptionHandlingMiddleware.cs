using InvoiceApp.Application.Exceptions;
using InvoiceApp.Application.Models;
using Newtonsoft.Json;

namespace InvoiceApp.API;

public class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.Message);

        var code = StatusCodes.Status500InternalServerError;
        var errors = new Dictionary<string, List<string>>();

        errors.Add("exception", new List<string> {
            ex.Message
        });

        code = ex switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            // ResourceNotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            // UnprocessableRequestException => StatusCodes.Status422UnprocessableEntity,
            _ => code
        };

        var result = JsonConvert.SerializeObject(ApiResult<string>.Failure(errors));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        return context.Response.WriteAsync(result);
    }
}