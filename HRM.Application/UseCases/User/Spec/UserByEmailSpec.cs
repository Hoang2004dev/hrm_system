using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HRM.Application.UseCases.User.Spec
{
    public class UserByEmailSpec : Specification<Domain.Entities.User>
    {
        public UserByEmailSpec(string email)
        {
            Query.Where(u => u.Email == email && u.IsActive == true);
        }
    }
}
