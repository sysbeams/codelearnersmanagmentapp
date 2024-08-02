using Application.Contracts.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos;
using Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Application.Services;

    public class UserService(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository) : IUserService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;
        private readonly IUserRepository _userRepository = userRepository;
        public string GenerateToken(UserResponse user)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserResponse user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress));

           /* foreach (var role in user.Roles)
                claims.AddClaim(new Claim(ClaimTypes.Role, role));*/

            return claims;
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

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password + userExist.PasswordSalt);

        bool isPasswordValid = hashedPassword == userExist.PasswordHash;
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

