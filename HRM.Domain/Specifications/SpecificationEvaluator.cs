using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HRM.Domain.Specifications
{
    public static class SpecificationEvaluator<T>
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            return inputQuery.Where(spec.Criteria);
        }
    }

}
