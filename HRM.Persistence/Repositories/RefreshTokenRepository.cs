using HRM.Application.Interfaces.Repositories;
using HRM.Domain.Entities;
using HRM.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Persistence.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(HRMDbContext context) : base(context) { }
    }
}
