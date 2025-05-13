using HRM.Application.Interfaces.Repositories;
using HRM.Application.Interfaces.Services;
using HRM.Application.UseCases.Auth.Dtos;
using HRM.Application.UseCases.Auth.Specs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Auth.Commands
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, AuthResponseDto>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<AuthResponseDto> Handle(RefreshTokenCommand request, CancellationToken ct)
        {
            var token = await _refreshTokenRepo.FirstOrDefaultAsync(new RefreshTokenValidSpec(request.Token), ct);
            if (token == null)
                throw new UnauthorizedAccessException("Invalid refresh token.");

            var user = await _userRepo.FirstOrDefaultAsync(new UserWithProjectRolesSpec(token.User.Username), ct);

            var newAccessToken = _jwtService.GenerateAccessToken(user!);
            var newRefreshToken = _jwtService.GenerateRefreshToken(user.Id);

            token.IsActive = 0;
            await _refreshTokenRepo.AddAsync(newRefreshToken, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return new AuthResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }
    }
}
