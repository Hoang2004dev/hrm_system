using HRM.API.Middlewares;
using HRM.Application.DTOs.Department;
using HRM.Application.UseCases.Department;
using HRM.Application.UseCases.Department.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] DepartmentCreateDTO request, CancellationToken cancellationToken)
        {
            var command = new CreateDepartmentCommand(request);
            var departmentId = await _mediator.Send(command, cancellationToken);

            // Nếu tạo thành công, trả về ApiResponse với thông tin departmentId
            return CreatedAtAction(nameof(Create), new { id = departmentId }, ApiResponse<object>.Success(new { id = departmentId }));
        }
    }
}

