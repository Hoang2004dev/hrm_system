using HRM.Application.Specifications.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.User
{
    public class UsernameSpec : BaseSpecification<Domain.Entities.User>
    {
        public UsernameSpec(string userName) 
        {
            AddCriteria(u => u.Username == userName);
        }
    }
}
