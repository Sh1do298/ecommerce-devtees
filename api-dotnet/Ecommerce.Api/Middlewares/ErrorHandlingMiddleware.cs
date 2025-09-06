using System.Net;
using System.Text.Json;

namespace Ecommerce.Api.Middlewares;

public class ErrorHandlingMiddleware {
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        try {
            await _next(context);
        }
        catch (Exception ex) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new {
                message = "Erro interno no servidor",
                detail = ex.Message
            });
            await context.Response.WriteAsync(result);
        }
    }
}
