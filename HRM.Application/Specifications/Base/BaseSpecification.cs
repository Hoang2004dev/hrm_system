using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HRM.Application.Specifications.Base
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; } = e => true;
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; protected set; }
        public Func<IOrderedQueryable<T>, IOrderedQueryable<T>>? ThenBy { get; protected set; }

        public int? Skip { get; private set; }
        public int? Take { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        protected void AddCriteria(Expression<Func<T, bool>> newCriteria)
        {
            Criteria = ExpressionCombiner.AndAlso(Criteria, newCriteria);
        }

        protected void AddOrCriteria(Expression<Func<T, bool>> newCriteria)
        {
            Criteria = ExpressionCombiner.OrElse(Criteria, newCriteria);
        }

        protected void ClearCriteria()
        {
            Criteria = e => true;
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescExpression)
        {
            OrderBy = orderByDescExpression;
        }

        protected void ApplyThenBy(Func<IOrderedQueryable<T>, IOrderedQueryable<T>> thenByExpression)
        {
            ThenBy = thenByExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        IReadOnlyList<Expression<Func<T, object>>> ISpecification<T>.Includes => Includes;
    }
}

