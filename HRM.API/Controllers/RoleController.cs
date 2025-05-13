using HRM.Application.UseCases.Role.Queries;
using HRM.Application.DTOs.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HRM.API.Middlewares;
using HRM.API.Filters.Attributes;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[LogAction]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Role/current/user/{userId}
        [HttpGet("current/user/{userId}")]
        //[ExecutionTime]
        public async Task<ActionResult<ApiResponse<List<RoleResponseDTO>>>> GetCurrentRolesByUserId(int userId, CancellationToken cancellationToken)
        {
            var query = new GetCurrentRolesByUserIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);

            //Nếu kết quả trả về null hoặc không có data, có thể trả về phản hồi NoContent
            if (result == null || !result.Any())
            {
                return Ok(ApiResponse<List<RoleResponseDTO>>.NoContent("No roles found for this user."));
            }

            return Ok(ApiResponse<List<RoleResponseDTO>>.Success(result));
        }
    }
}


