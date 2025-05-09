using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Application.Specifications.Base;
using HRM.Domain.Entities;

namespace HRM.Application.Specifications.Spec.Auth
{
    public class LoginSpec : BaseSpecification<Domain.Entities.User>
    {
        public LoginSpec(string email)
        {
            AddCriteria(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
