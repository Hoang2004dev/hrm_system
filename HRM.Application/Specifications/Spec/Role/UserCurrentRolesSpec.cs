using HRM.Application.Specifications.Base;
using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Spec.Role
{
    public class UserCurrentRolesSpec : BaseSpecification<UserProjectRole>
    {
        public UserCurrentRolesSpec(int userId)
        {
            // Điều kiện: UserId khớp
            AddCriteria(upr => upr.UserId == userId);

            // Include các quan hệ cần để truy vấn sâu
            AddInclude(upr => upr.Role);
            AddInclude(upr => upr.Project);
            AddInclude(upr => upr.Project.ProjectStatuses);

            // Điều kiện trong Project.ProjectStatuses: "InProgress" và ToDate == null
            AddCriteria(upr => upr.Project.ProjectStatuses
                .Any(ps => ps.Status == "InProgress" && ps.ToDate == null));
        }
    }

}
