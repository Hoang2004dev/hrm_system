using HRM.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

namespace HRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestExceptionController : ControllerBase
    {
        private readonly ILogger<TestExceptionController> _logger;

        public TestExceptionController(ILogger<TestExceptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("notfound")]
        public IActionResult TestNotFoundException()
        {
            _logger.LogInformation("Testing NotFoundException");
            throw new NotFoundException("Test NotFoundException");
        }

        [HttpGet("badrequest")]
        public IActionResult TestBadRequestException()
        {
            _logger.LogInformation("Testing BadRequestException");
            throw new BadRequestException("Test BadRequestException");
        }

        [HttpGet("unhandled")]
        public IActionResult TestUnhandledException()
        {
            _logger.LogInformation("Testing unhandled exception");
            throw new InvalidOperationException("This is an unhandled exception test");
        }

        [HttpGet("success")]
        public IActionResult TestSuccess()
        {
            _logger.LogInformation("Testing successful request");
            return Ok(new { message = "This endpoint works without throwing exceptions" });
        }
    }
}