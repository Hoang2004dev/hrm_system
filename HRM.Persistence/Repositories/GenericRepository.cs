using HRM.Application.Interfaces.Repositories;
using HRM.Application.Specifications.Base;
using HRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HRMDbContext _context;
        private readonly ISpecificationEvaluator<T> _specEvaluator;

        public GenericRepository(HRMDbContext context, ISpecificationEvaluator<T> specEvaluator)
        {
            _context = context;
            _specEvaluator = specEvaluator;
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.Set<T>().ToListAsync(cancellationToken);

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _context.Set<T>().AddAsync(entity, cancellationToken);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _specEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> FindAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _specEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);


            string sql = query.ToQueryString();
            Debug.Print(sql);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
