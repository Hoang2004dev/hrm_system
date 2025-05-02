using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HRM.Domain.Specifications
{
    public abstract class BaseSpecification<T>
    {
        public abstract Expression<Func<T, bool>> Criteria { get; }

        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; protected set; } = null;

        public List<Expression<Func<T, object>>> Includes { get; } = new();

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        protected void ApplyOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            OrderBy = orderBy;
        }
    }
}
