using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Filters.AuthorizationFilters
{
    public class PermissionAuthorizationFilter : IAuthorizationFilter
    {
        private readonly string _permission;

        public PermissionAuthorizationFilter(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated || !user.HasClaim("Permission", _permission))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
