using HRM.Application.Interfaces;
using HRM.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRMDbContext _context;

        public UnitOfWork(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
