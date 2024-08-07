using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Jwt;
    public class JwtSettings : IValidatableObject
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int TokenExpirationInMinutes { get; set; }
        public int RefreshTokenExpirationInDays { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Key) || Key.Length < 32)
            {
                yield return new ValidationResult("Key must be at least 32 characters long.", new[] { nameof(Key) });
            }
        }
    }

