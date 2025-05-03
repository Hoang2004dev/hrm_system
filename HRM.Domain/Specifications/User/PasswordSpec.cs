using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Domain.Entities;

namespace HRM.Domain.Specifications.User
{
    public class PasswordSpec : BaseSpecification<Entities.User>
    {
        public PasswordSpec(string password) 
        {
            AddCriteria(u => u.PasswordHash == password);
        }
    }
}
