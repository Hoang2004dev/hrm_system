using HRM.Application.UseCases.Role.Queries;
using HRM.Application.DTOs.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Role/current/user/{userId}
        [HttpGet("current/user/{userId}")]
        public async Task<ActionResult<List<RoleResponseDTO>>> GetCurrentRolesByUserId(int userId, CancellationToken cancellationToken)
        {
            var query = new GetCurrentRolesByUserIdQuery(userId);
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}

