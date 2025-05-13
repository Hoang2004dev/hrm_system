using HRM.Application.DTOs.Auth;
using HRM.Application.UseCases.Auth.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Auth.Commands
{
    public record LoginCommand(string Username, string Password) : IRequest<AuthResponseDto>;
}
