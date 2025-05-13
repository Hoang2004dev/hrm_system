using Microsoft.AspNetCore.Mvc.Filters;

namespace HRM.API.Filters.ResourceFilters
{
    public class CachingResourceFilter : IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Kiểm tra cache, nếu có thì trả kết quả luôn
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // Ghi vào cache nếu cần
        }
    }
}
