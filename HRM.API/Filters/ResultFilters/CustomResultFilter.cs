using Microsoft.AspNetCore.Mvc.Filters;

namespace HRM.API.Filters.ResultFilters
{
    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Custom-Header", "MyValue");
        }

        public void OnResultExecuted(ResultExecutedContext context) { }
    }
}
