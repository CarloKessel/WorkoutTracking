namespace API.AuthMiddelware;

public class ApiGatewayMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public ApiGatewayMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context)
    {
        var apiKey = _configuration.GetValue<string>("APIGateway:ApiKey");
        context.Request.Headers.TryGetValue("X-Api-Gateway-Key", out var test);

        if (!context.Request.Headers.TryGetValue("X-Api-Gateway-Key", out var extractedApiKey) || !apiKey.Equals(extractedApiKey))
        {
            context.Response.StatusCode = 403; // Forbidden
            await context.Response.WriteAsync("Access forbidden.");
            return;
        }

        await _next(context);
    }
}

public static class ApiGatewayMiddlewareExtensions
{
    public static IApplicationBuilder UseApiGatewayMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ApiGatewayMiddleware>();
    }
}
