using HRM.API.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Filters.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ValidateModelAttribute : TypeFilterAttribute
    {
        public ValidateModelAttribute() : base(typeof(ValidateModelFilter)) { }
    }
}
