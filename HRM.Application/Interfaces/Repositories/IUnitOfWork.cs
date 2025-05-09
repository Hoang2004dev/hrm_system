using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        IRoleRepository Roles { get; }
        IUserProjectRoleRepository UserProjectRoles { get; }
        // ... Các repository khác

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
