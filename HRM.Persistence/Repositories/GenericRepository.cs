using HRM.Domain.Interfaces;
using HRM.Domain.Specifications;
using HRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HRMDbContext _context;

        public GenericRepository(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);
        public async Task<List<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<List<T>> FindAsync(BaseSpecification<T> spec)
        {
            IQueryable<T> query = _context.Set<T>();

            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            foreach (var include in spec.Includes)
                query = query.Include(include);

            if (spec.OrderBy != null)
                query = spec.OrderBy(query);

            return await query.ToListAsync();
        }
    }
}
