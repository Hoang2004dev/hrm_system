using HRM.Application.DTOs.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Auth.Commands
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
