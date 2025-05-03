using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain.Specifications.Role
{
    public class IdSpec : BaseSpecification<Entities.Role>
    {
        public IdSpec(int id) 
        {
            AddCriteria(r => r.Id == id);
        }
    }
}
