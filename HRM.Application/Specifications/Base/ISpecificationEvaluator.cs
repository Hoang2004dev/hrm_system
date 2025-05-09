using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Base
{
    public interface ISpecificationEvaluator<T>
    {
        IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec);
    }
}
