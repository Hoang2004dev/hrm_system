using AutoMapper;
using FluentValidation;
using HRM.Application.DTOs.Auth;
using HRM.Application.Interfaces.Repositories;
using HRM.Application.Interfaces.Services;
using HRM.Application.UseCases.Auth.Dtos;
using HRM.Application.UseCases.Auth.Specs;
using HRM.Application.UseCases.Auth.Validators;
using MediatR;

namespace HRM.Application.UseCases.Auth.Commands
{
    public class LoginHandler : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly IUnitOfWork _unitOfWork;

        public LoginHandler(IUserRepository userRepo, IJwtService jwtService,
            IRefreshTokenRepository refreshTokenRepo, IUnitOfWork unitOfWork, 
            IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
            _refreshTokenRepo = refreshTokenRepo;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken ct)
        {
            var spec = new UserWithProjectRolesSpec(request.Username);
            var user = await _userRepo.FirstOrDefaultAsync(spec, ct);

            if (user is null || !_passwordHasher.Verify(user.PasswordHash, request.Password))
                throw new UnauthorizedAccessException("Invalid username or password.");

            var accessToken = _jwtService.GenerateAccessToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken(user.Id);

            await _refreshTokenRepo.AddAsync(refreshToken, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return new AuthResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };
        }
    }

}
