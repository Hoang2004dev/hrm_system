using Ardalis.Specification;
using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HRM.Application.UseCases.Auth.Specs
{
    public class RefreshTokenValidSpec : Specification<RefreshToken>
    {
        public RefreshTokenValidSpec(string token)
        {
            Query
                .Where(rt => rt.Token == token && rt.ExpiresAt > DateTime.UtcNow && rt.IsActive == 1)
                .Include(rt => rt.User);
        }
    }
}
