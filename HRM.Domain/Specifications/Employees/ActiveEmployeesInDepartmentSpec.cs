using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using HRM.Domain.Entities;

namespace HRM.Domain.Specifications.Employees
{
    public class ActiveEmployeesInDepartmentSpec : BaseSpecification<Employee>
    {
        private readonly int _departmentId;

        public ActiveEmployeesInDepartmentSpec(int departmentId)
        {
            _departmentId = departmentId;
        }

        public override Expression<Func<Employee, bool>> Criteria =>
            e => e.DepartmentId == _departmentId;
    }

}
