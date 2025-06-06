﻿using HRM.Application.Interfaces.Repositories;
using HRM.Persistence.Contexts;

namespace HRM.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRMDbContext _context;

        public IUserRepository Users { get; }
        public IDepartmentRepository Departments { get; }
        public IEmployeeRepository Employees { get; }
        public IRoleRepository Roles { get; }
        public IUserProjectRoleRepository UserProjectRoles { get; }

        public UnitOfWork(
            HRMDbContext context,
            IUserRepository users,
            IDepartmentRepository departments,
            IEmployeeRepository employees,
            IRoleRepository roles,
            IUserProjectRoleRepository userProjectRoles)
        {
            _context = context;
            Users = users;
            Departments = departments;
            Employees = employees;
            Roles = roles;
            UserProjectRoles = userProjectRoles;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
    }
}
