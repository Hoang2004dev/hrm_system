using Ardalis.Specification;

namespace HRM.Application.Specifications.Spec.User
{
    public class UserIdSpec : Specification<Domain.Entities.User>
    {
        public UserIdSpec(int userId)
        {
            Query.Where(upr => upr.Id == userId);
        }
    }

}
