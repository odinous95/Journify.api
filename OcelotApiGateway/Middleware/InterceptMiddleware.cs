namespace OcelotApiGateway.Middleware
{
    public class InterceptMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers["Referrer"] = "Api-Gateway";
            await next(context);
        }
    }
}
