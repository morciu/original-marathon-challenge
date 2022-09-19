namespace WebAPI.Middleware
{
    public class RequestTimeLogger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimeLogger> _logger;
        public RequestTimeLogger(RequestDelegate next, ILogger<RequestTimeLogger> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Log time of request
            _logger.LogInformation($"Time of Request: {DateTime.Now}");

            await _next.Invoke(httpContext);

            // Log time of response
            _logger.LogInformation($"Time of Response: {DateTime.Now}");
        }
    }
    // Extension method to use custom middleware
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeLogger>();
        }
    }
}
