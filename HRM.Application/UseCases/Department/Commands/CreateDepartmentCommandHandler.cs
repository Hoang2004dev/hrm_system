using AutoMapper;
using HRM.Application.DTOs.Department;
using HRM.Application.Interfaces.Repositories;
using HRM.Domain.Entities;
using MediatR;

namespace HRM.Application.UseCases.Department.Commands
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepartmentCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DepartmentResponseDTO> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Domain.Entities.Department>(request.DepartmentDto);

            await _unitOfWork.Departments.AddAsync(department, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DepartmentResponseDTO>(department);
        }
    }
}
