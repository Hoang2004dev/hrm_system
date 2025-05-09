using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Base
{
    public class AndSpecification<T> : BaseSpecification<T>
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            AddCriteria(ExpressionCombiner.AndAlso(left.Criteria, right.Criteria));
        }
    }
}
