using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using TravelAndAccommodationBookingPlatform.Domain.Exceptions;

namespace TravelAndAccommodationBookingPlatform.API.CustomMiddleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (HotelNotFound ex)
        {
            _logger.LogError($"Hotel Not Found: {ex.Message}");
            await HandleHotelNotFoundExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleHotelNotFoundExceptionAsync(HttpContext context, HotelNotFound exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.NotFound; // 404 Not Found

        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message ?? "Hotel not found."
        }.ToString());
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error from the middleware."
        }.ToString());
    }
}

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}