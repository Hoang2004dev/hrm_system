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
    public class UserProjectRoleRepository : GenericRepository<UserProjectRole>, IUserProjectRoleRepository
    {
        public UserProjectRoleRepository(HRMDbContext context) : base(context) { }
    }
}
