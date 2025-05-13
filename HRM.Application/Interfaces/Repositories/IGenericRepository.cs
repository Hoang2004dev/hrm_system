using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HRM.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Basic CRUD operations
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);

        // Specification-based queries
        Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<List<T>> FindAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        // Additional specification-based methods
        Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> spec, CancellationToken cancellationToken = default);
        Task<List<TResult>> FindAsync<TResult>(ISpecification<T, TResult> spec, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);
    }
}