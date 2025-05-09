using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Projection
{
    public class OrSpecification<T, TResult> : BaseSpecification<T, TResult>
    {
        public OrSpecification(ISpecification<T, TResult> left, ISpecification<T, TResult> right)
        {
            AddCriteria(ExpressionCombiner.OrElse(left.Criteria, right.Criteria));
        }
    }
}
