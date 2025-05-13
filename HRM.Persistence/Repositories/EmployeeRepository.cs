using HRM.Application.Interfaces.Repositories;
using HRM.Application.Specifications.Base;
using HRM.Domain;
using HRM.Domain.Entities;
using HRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRM.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HRMDbContext context) : base(context) { }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
