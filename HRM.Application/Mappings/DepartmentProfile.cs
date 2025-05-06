using AutoMapper;
using HRM.Application.DTOs.Department;
using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Mappings
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentResponseDTO>();
            CreateMap<DepartmentCreateDTO, Department>();
        }
    }
}
