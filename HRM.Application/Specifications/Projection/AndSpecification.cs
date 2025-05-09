using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Projection
{
    public class AndSpecification<T, TResult> : BaseSpecification<T, TResult>
    {
        public AndSpecification(ISpecification<T, TResult> left, ISpecification<T, TResult> right)
        {
            AddCriteria(ExpressionCombiner.AndAlso(left.Criteria, right.Criteria));
        }
    }
}
