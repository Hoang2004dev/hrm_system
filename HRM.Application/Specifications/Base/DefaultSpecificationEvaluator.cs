using HRM.Application.Specifications.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Base
{
    public class DefaultSpecificationEvaluator<T> : ISpecificationEvaluator<T> where T : class
    {
        public IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
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

            return query;
        }
    }
}
