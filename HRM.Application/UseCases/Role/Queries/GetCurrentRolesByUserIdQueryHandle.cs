using AutoMapper;
using HRM.Application.DTOs.Role;
using HRM.Application.Exceptions;
using HRM.Application.Interfaces.Repositories;
using HRM.Application.Specifications.Spec.Role;
using HRM.Domain.Entities;
using MediatR;

namespace HRM.Application.UseCases.Role.Queries
{
    public class GetCurrentRolesByUserIdQueryHandler : IRequestHandler<GetCurrentRolesByUserIdQuery, List<RoleResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCurrentRolesByUserIdQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RoleResponseDTO>> Handle(GetCurrentRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Sử dụng Specification để truy vấn
            var spec = new UserCurrentRolesSpec(request.UserId);
            var userProjectRoles = await _unitOfWork.UserProjectRoles.FindAsync(spec, cancellationToken);

            if (userProjectRoles == null || !userProjectRoles.Any())
                throw new NotFoundException($"No current roles found for User with ID = {request.UserId}");

            // Map kết quả từ UserProjectRole sang RoleResponseDTO
            var roles = userProjectRoles.Select(upr => upr.Role).Distinct().ToList();

            return _mapper.Map<List<RoleResponseDTO>>(roles);
        }
    }
}
