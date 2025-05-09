using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Specifications.Base
{
    public class OrSpecification<T> : BaseSpecification<T>
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            AddCriteria(ExpressionCombiner.OrElse(left.Criteria, right.Criteria));
        }
    }
}
