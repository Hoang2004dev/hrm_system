using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// HRM.Domain/Specifications/ISpecification.cs
using System;
using System.Linq.Expressions;

namespace HRM.Domain.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }

}
