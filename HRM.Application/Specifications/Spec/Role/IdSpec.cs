using HRM.Application.Specifications.Base;
using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Spec.Role
{
    public class IdSpec : BaseSpecification<Domain.Entities.Role>
    {
        public IdSpec(int id) 
        {
            AddCriteria(r => r.Id == id);
        }
    }
}
