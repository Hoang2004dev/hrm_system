using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain.Specifications.User
{
    public class UsernameSpec : BaseSpecification<Entities.User>
    {
        public UsernameSpec(string userName) 
        {
            AddCriteria(u => u.Username == userName);
        }
    }
}
