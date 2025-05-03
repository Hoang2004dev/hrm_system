using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain.Specifications.Employees
{
    public class DepartmentSpec : BaseSpecification<Employee>
    {
        public DepartmentSpec(int deptId)
        {
            AddCriteria(e => e.DepartmentId == deptId);
        }
    }
}
