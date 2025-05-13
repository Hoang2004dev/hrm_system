using HRM.Application.UseCases.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Auth.Commands
{
    public record RegisterCommand(
        string Username,
        string Password,
        string Email,
        string FullName
    ) : IRequest<AuthResponseDto>; // Có thể đổi sang `Unit` nếu không cần trả token
}
