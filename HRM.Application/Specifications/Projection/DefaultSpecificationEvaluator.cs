using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Projection
{
    public class DefaultSpecificationEvaluator<T, TResult> : ISpecificationEvaluator<T, TResult> where T : class
    {
        public IQueryable<TResult> GetQuery(IQueryable<T> inputQuery, ISpecification<T, TResult> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
                query = query.Where(spec.Criteria);

            foreach (var include in spec.Includes)
                query = query.Include(include);

            if (spec.OrderBy != null)
            {
                var orderedQuery = spec.OrderBy(query);
                if (spec.ThenBy != null)
                    orderedQuery = spec.ThenBy(orderedQuery);

                query = orderedQuery;
            }

            if (spec.IsPagingEnabled)
            {
                if (spec.Skip.HasValue)
                    query = query.Skip(spec.Skip.Value);
                if (spec.Take.HasValue)
                    query = query.Take(spec.Take.Value);
            }

            if (spec.Selector != null)
                return query.Select(spec.Selector);
            else
                throw new InvalidOperationException("Selector (projection) must be defined.");

        }
    }
}
