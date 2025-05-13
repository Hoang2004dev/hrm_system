using Ardalis.Specification;
using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HRM.Application.UseCases.Auth.Specs
{
    public class UserWithProjectRolesSpec : Specification<Domain.Entities.User>
    {
        public UserWithProjectRolesSpec(string username)
        {
            Query
                .Where(u => u.Username == username && u.IsActive == true)
                .Include(u => u.UserProjectRoles)
                    .ThenInclude(upr => upr.Role);
        }
    }
}
