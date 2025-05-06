using AutoMapper;
using HRM.Application.DTOs.Role;
using HRM.Application.Exceptions;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using HRM.Domain.Specifications.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Role.Queries
{
    public class GetCurrentRolesByUserIdQueryHandler : IRequestHandler<GetCurrentRolesByUserIdQuery, List<RoleResponseDTO>>
    {
        private readonly IUserProjectRoleRepository _userProjectRoleRepository; // Đảm bảo bạn đã có IRepository được inject vào đây
        private readonly IMapper _mapper;

        public GetCurrentRolesByUserIdQueryHandler(IUserProjectRoleRepository userProjectRoleRepository, IMapper mapper)
        {
            _userProjectRoleRepository = userProjectRoleRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleResponseDTO>> Handle(GetCurrentRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Sử dụng Specification để truy vấn
            var spec = new UserCurrentRolesSpec(request.UserId);
            var userProjectRoles = await _userProjectRoleRepository.FindAsync(spec, cancellationToken);

            if (userProjectRoles == null || !userProjectRoles.Any())
                throw new NotFoundException($"No current roles found for User with ID = {request.UserId}");

            // Map kết quả từ UserProjectRole sang RoleResponseDTO
            var roles = userProjectRoles.Select(upr => upr.Role).Distinct().ToList();

            return _mapper.Map<List<RoleResponseDTO>>(roles);
        }
    }
}
