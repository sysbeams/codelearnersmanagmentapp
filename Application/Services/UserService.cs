using Application.Contracts.Services;
using Application.Dtos;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public string GenerateToken(UserResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.EmailAddress)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:TokenExpirationInMinutes"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Login request cannot be null.");
            }

            var userExist = await _userRepository.GetUserByAsync(u => u.EmailAddress == request.EmailAddress);
            if (userExist == null)
            {
                throw new ValidationException("Invalid Password Or Email");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password + userExist.PasswordSalt, userExist.PasswordHash);
            if (!isPasswordValid)
            {
                throw new ValidationException("Invalid Password Or Email");
            }

            var user = new UserResponse
            {
                Id = userExist.Id,
                EmailAddress = userExist.EmailAddress,
                UserName = userExist.UserName
            };

            var token = GenerateToken(user);
            return new LoginResponse
            (
                EmailAddress: userExist.EmailAddress,
                Message: "Successfully logged in",
                IsSuccessful: true,
                Token: token
            );
        }
    }
}
