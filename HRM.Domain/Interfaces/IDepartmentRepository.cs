using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        // Bổ sung thêm các method đặc thù nếu cần
    }
}
