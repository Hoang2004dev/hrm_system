using HRM.Application.DTOs.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Role.Queries
{
    public class GetCurrentRolesByUserIdQuery : IRequest<List<RoleResponseDTO>>
    {
        public int UserId { get; }

        public GetCurrentRolesByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
