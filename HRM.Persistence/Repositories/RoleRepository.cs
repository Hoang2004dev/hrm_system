using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using HRM.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(HRMDbContext context) : base(context) { }
    }
}
