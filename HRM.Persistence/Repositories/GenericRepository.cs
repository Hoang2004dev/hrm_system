using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using HRM.Application.Interfaces.Repositories;
using HRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRM.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly HRMDbContext _context;
        private readonly ISpecificationEvaluator _specEvaluator;

        public GenericRepository(HRMDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _specEvaluator = SpecificationEvaluator.Default;
        }

        // Basic CRUD operations
        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        // Specification-based queries
        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var query = ApplySpecification(spec);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<T>> FindAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var query = ApplySpecification(spec);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> spec, CancellationToken cancellationToken = default)
        {
            var query = ApplySpecification(spec);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TResult>> FindAsync<TResult>(ISpecification<T, TResult> spec, CancellationToken cancellationToken = default)
        {
            var query = ApplySpecification(spec);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var query = ApplySpecification(spec);
            return await query.CountAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var query = ApplySpecification(spec);
            return await query.AnyAsync(cancellationToken);
        }

        // Helper method to apply specification
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return _specEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> spec)
        {
            return _specEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}