using HRM.Application.DTOs.Auth;
using HRM.Application.Exceptions;
using HRM.Domain.Entities;
using HRM.Infrastructure.Auth;
using HRM.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("test-exception")]
        public IActionResult TestError()
        {
            throw new NotFoundException("Test exception from controller");
        }

    }
}
