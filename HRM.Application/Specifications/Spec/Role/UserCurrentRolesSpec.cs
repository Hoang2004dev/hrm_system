using Ardalis.Specification;
using HRM.Domain.Entities;

namespace HRM.Application.Specifications.Spec.Role
{
    public class UserCurrentRolesSpec : Specification<UserProjectRole>
    {
        public UserCurrentRolesSpec(int userId)
        {
            Query
                .Where(upr => upr.UserId == userId)
                .Where(upr => upr.Project.ProjectStatuses
                    .Any(ps => ps.Status == "InProgress" && ps.ToDate == null))
                .Include(upr => upr.Role)
                .Include(upr => upr.Project)
                    .ThenInclude(p => p.ProjectStatuses);
        }
    }
}

