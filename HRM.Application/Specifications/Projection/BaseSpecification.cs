using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HRM.Application.Specifications.Projection
{
    public abstract class BaseSpecification<T, TResult> : ISpecification<T, TResult>
    {
        public Expression<Func<T, bool>> Criteria { get; private set; } = e => true;
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; protected set; }
        public Func<IOrderedQueryable<T>, IOrderedQueryable<T>>? ThenBy { get; protected set; }
        public Expression<Func<T, TResult>>? Selector { get; protected set; }

        public int? Skip { get; private set; }
        public int? Take { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        /// <summary>Thêm điều kiện lọc vào tiêu chí truy vấn.</summary>
        protected void AddCriteria(Expression<Func<T, bool>> newCriteria)
        {
            Criteria = ExpressionCombiner.AndAlso(Criteria, newCriteria);
        }

        /// <summary>Thêm include để eager loading dữ liệu liên quan.</summary>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>Sắp xếp tăng dần theo biểu thức.</summary>
        protected void ApplyOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        /// <summary>Sắp xếp giảm dần theo biểu thức.</summary>
        protected void ApplyOrderByDescending(Func<IQueryable<T>, IOrderedQueryable<T>> orderByDescExpression)
        {
            OrderBy = orderByDescExpression;
        }

        /// <summary>Sắp xếp tiếp theo sau OrderBy.</summary>
        protected void ApplyThenBy(Func<IOrderedQueryable<T>, IOrderedQueryable<T>> thenByExpression)
        {
            ThenBy = thenByExpression;
        }

        /// <summary>Chọn projection để trả về dữ liệu dưới dạng DTO.</summary>
        protected void ApplySelector(Expression<Func<T, TResult>> selector)
        {
            Selector = selector;
        }

        /// <summary>Áp dụng phân trang cho truy vấn.</summary>
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        // Expose Includes as read-only
        IReadOnlyList<Expression<Func<T, object>>> ISpecification<T, TResult>.Includes => Includes;
    }
}

