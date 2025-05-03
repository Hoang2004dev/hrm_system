using AutoMapper;
using FluentValidation;
using HRM.Application.DTOs.Auth;
using HRM.Application.Interfaces;
using HRM.Application.UseCases.Auth.Validators;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using HRM.Domain.Specifications;
using HRM.Domain.Specifications.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Auth.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly LoginValidator _loginValidator;
        private readonly IUserRepository _userRepository;
        private readonly IHashingService _hashingService;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(LoginValidator loginValidator, IUserRepository userRepository, 
            IHashingService hashingService, IJwtService jwtService)
        {
            _loginValidator = loginValidator;
            _userRepository = userRepository;
            _hashingService = hashingService;
            _jwtService = jwtService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _loginValidator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var spec = new UsernameSpec(request.Username);
            var user = await _userRepository.FirstOrDefaultAsync(spec);

            if (user is null || !_hashingService.VerifyPassword(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password.");

            //var roles = await _userRepository.GetRolesAsync(user.Id); // thêm hàm này nếu chưa có

            //var accessToken = _jwtService.GenerateAccessToken(user, roles);
            //var refreshToken = _jwtService.GenerateRefreshToken(user.Id);

            //await _refreshTokenRepository.AddAsync(refreshToken);
            //await _unitOfWork.SaveChangesAsync();

            //return new LoginResponse
            //{
            //    AccessToken = accessToken,
            //    RefreshToken = refreshToken.Token,
            //    ExpiresIn = (int)TimeSpan.FromMinutes(_jwtOptions.AccessTokenExpirationMinutes).TotalSeconds
            //};
            return null;
        }

    }
}
