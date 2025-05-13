using Microsoft.AspNetCore.Mvc.Filters;

namespace HRM.API.Filters.ActionFilters
{
    public class LoggingActionFilter : IActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("[LoggingActionFilter] Starting action {Action}", context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("[LoggingActionFilter] Finished action {Action}", context.ActionDescriptor.DisplayName);
        }
    }
}
