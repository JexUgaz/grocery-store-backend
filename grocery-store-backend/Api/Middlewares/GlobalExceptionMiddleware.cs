using System.Text.Json;
using System.Text.Json.Serialization;
using grocery_store_backend.Config.Exceptions;
using grocery_store_backend.Domain.Api;

namespace grocery_store_backend.Api.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger = logger;
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() }
    };

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);

            var path = context.Request.Path;
            var statusCode = context.Response.StatusCode;
            if (statusCode == StatusCodes.Status404NotFound) throw new NotFoundException($"No resource found for path: {path}");
            if (statusCode == StatusCodes.Status405MethodNotAllowed) throw new MethodNotAllowedException(context.Request.Method);
            if (statusCode == StatusCodes.Status415UnsupportedMediaType) throw new UnsupportedMediaTypeException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught.");
            var response = ApiResponse<object>.Exception(ex);
            await HandleExceptionAsync(context, response);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, ApiResponse<object> response)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = response.Error!.Code;

        var json = JsonSerializer.Serialize(response, _jsonOptions);
        return context.Response.WriteAsync(json);
    }

}
