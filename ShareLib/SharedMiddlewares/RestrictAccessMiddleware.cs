using Microsoft.AspNetCore.Http;

namespace ShareLib.SharedMiddlewares
{
    public class RestrictAccessMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            var referrer = context.Request.Headers["Referer"].FirstOrDefault();
            if (string.IsNullOrEmpty(referrer) || !referrer.Contains("Api-Gateway"))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access Denied: Invalid Referrer");
                return;
            }
            else
            {
                await next(context);
            }
        }
    }
}
