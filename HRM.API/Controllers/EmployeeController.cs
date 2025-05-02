using HRM.Application.UseCases.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        

            private readonly IMediator _mediator;

            public EmployeeController(IMediator mediator)
            {
                _mediator = mediator;
            }

            // GET: api/employees
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _mediator.Send(new GetAllEmployeesQuery());
                return Ok(result);
            }
        
    }
}
