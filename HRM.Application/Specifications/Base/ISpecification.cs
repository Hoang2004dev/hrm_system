using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace HRM.Application.Specifications.Base
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        IReadOnlyList<Expression<Func<T, object>>> Includes { get; }
        Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; }
        Func<IOrderedQueryable<T>, IOrderedQueryable<T>>? ThenBy { get; }
        int? Skip { get; }
        int? Take { get; }
        bool IsPagingEnabled { get; }
    }
}

