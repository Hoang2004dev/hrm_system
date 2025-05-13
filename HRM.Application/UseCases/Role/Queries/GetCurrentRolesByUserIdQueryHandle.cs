using AutoMapper;
using HRM.Application.DTOs.Employee;
using HRM.Application.DTOs.Role;
using HRM.Application.Exceptions;
using HRM.Application.Interfaces.Repositories;
using HRM.Application.Specifications.Spec.Role;
using HRM.Application.Specifications.Spec.User;
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
            // Kiểm tra userId có tồn tại hay không trước
            var userExists = await _unitOfWork.Users.AnyAsync(new UserIdSpec(request.UserId), cancellationToken);

            if (!userExists)
            {
                // Xử lý trường hợp không tồn tại userId
                throw new NotFoundException($"User with ID {request.UserId} does not exist.");
            }

            // Sử dụng Specification để truy vấn role của user
            var spec = new UserCurrentRolesSpec(request.UserId);
            var userProjectRoles = await _unitOfWork.UserProjectRoles.FindAsync(spec, cancellationToken);

            if (userProjectRoles == null || !userProjectRoles.Any())
            {
                // Xử lý trường hợp không có role nào
                return new List<RoleResponseDTO>();
            }

            // Map kết quả từ UserProjectRole sang RoleResponseDTO
            var roles = userProjectRoles.Select(upr => upr.Role).Distinct().ToList();
            return _mapper.Map<List<RoleResponseDTO>>(roles);
        }
    }
}
