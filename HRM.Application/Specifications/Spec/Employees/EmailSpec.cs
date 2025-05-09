using HRM.Application.Specifications.Base;
using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Spec.Employees
{
    public class EmailSpec : BaseSpecification<Employee>
    {
        public EmailSpec(string email)
        {
            AddCriteria(e => e.Email == email);
        }
    }
}
