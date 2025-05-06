using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using HRM.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(HRMDbContext context) : base(context) { }
    }
}
