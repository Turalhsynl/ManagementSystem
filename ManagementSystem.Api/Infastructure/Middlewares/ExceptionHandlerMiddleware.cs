using Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace ManagementSystem.Api.Infastructure.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            switch(error)
            {
                case BadRequestException:
                    var message = new List<string>() { error.Message };
                    await WriteError(context, message, HttpStatusCode.BadRequest);
                    break;

                case NotFoundException:
                    message = new List<string>() { error.Message };
                    await WriteError(context, message, HttpStatusCode.NotFound);
                    break;
            }
        }
    }

    static async Task WriteError(HttpContext context, List<string> messages, HttpStatusCode statusCode)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json; charset = utf-8";

        var options = new JsonSerializerOptions { };
        var json = JsonSerializer.Serialize(messages, options);
        await context.Response.WriteAsync(json);
    }
}
