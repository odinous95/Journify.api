using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journify.api.Filters
{
    public class GloblaExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GloblaExceptionFilter> _logger;
        public GloblaExceptionFilter(ILogger<GloblaExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "An unhandled exception occurred.");
            var response = new
            {
                Message = "An unexpected error occurred. Please try again later."
            };
            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
