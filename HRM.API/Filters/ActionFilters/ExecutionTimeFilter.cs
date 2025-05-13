using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace HRM.API.Filters.ActionFilters
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private readonly ILogger<ExecutionTimeFilter> _logger;
        private Stopwatch _stopwatch;

        public ExecutionTimeFilter(ILogger<ExecutionTimeFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Items["Stopwatch"] = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Items["Stopwatch"] is Stopwatch sw)
            {
                sw.Stop();
                var elapsed = sw.ElapsedMilliseconds;
                _logger.LogInformation("[ExecutionTimeFilter] Execution time for {Action}: {Time} ms",
                    context.ActionDescriptor.DisplayName, elapsed);
            }
        }
    }
}
