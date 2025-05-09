using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Projection
{
    public interface ISpecificationEvaluator<T, TResult>
    {
        IQueryable<TResult> GetQuery(IQueryable<T> inputQuery, ISpecification<T, TResult> spec);
    }
}
