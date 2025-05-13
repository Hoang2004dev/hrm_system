using HRM.Application.Interfaces.Repositories;
using HRM.Application.Interfaces.Services;
using HRM.Application.UseCases.Auth.Dtos;
using HRM.Application.UseCases.User.Spec;
using HRM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Auth.Commands
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthResponseDto>
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenRepository _refreshTokenRepo;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterHandler(
            IPasswordHasher passwordHasher,
            IUserRepository userRepo,
            IJwtService jwtService,
            IRefreshTokenRepository refreshTokenRepo,
            IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _userRepo = userRepo;
            _jwtService = jwtService;
            _refreshTokenRepo = refreshTokenRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthResponseDto> Handle(RegisterCommand request, CancellationToken ct)
        {
            // Kiểm tra trùng email
            var existing = await _userRepo.AnyAsync(new UserByEmailSpec(request.Email), ct);
            if (!existing)
                throw new Exception("Username or Email already exists");

            // Tạo user mới
            var newUser = new Domain.Entities.User
            {
                Username = request.Username,
                PasswordHash = _passwordHasher.Hash(request.Password),
                Email = request.Email,
                FullName = request.FullName,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _userRepo.AddAsync(newUser, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            // Sinh JWT
            var accessToken = _jwtService.GenerateAccessToken(newUser);
            var refreshToken = _jwtService.GenerateRefreshToken(newUser.Id);

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
