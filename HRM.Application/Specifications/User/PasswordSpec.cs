using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM.Application.DTOs.Auth;
using HRM.Application.Specifications.Base;
using HRM.Domain.Entities;

namespace HRM.Application.Specifications.User
{
    public class PasswordSpec : BaseSpecification<Domain.Entities.User>
    {
        public PasswordSpec(string password) 
        {
            AddCriteria(u => u.PasswordHash == password);
        }
    }
}
