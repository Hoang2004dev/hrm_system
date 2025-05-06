using AutoMapper;
using HRM.Application.DTOs.Department;
using HRM.Application.Interfaces;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;

namespace HRM.Application.UseCases.Department.Commands
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, DepartmentResponseDTO>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDepartmentCommandHandler(
            IDepartmentRepository departmentRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DepartmentResponseDTO> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Domain.Entities.Department>(request.DepartmentDto);

            await _departmentRepository.AddAsync(department, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DepartmentResponseDTO>(department);
        }
    }
}
