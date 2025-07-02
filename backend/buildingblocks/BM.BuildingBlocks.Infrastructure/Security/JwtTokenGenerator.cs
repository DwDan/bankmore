using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BM.BuildingBlocks.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BM.BuildingBlocks.Infrastructure.Security;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private string GenerateTokenInternal(IEnumerable<Claim> claims, DateTime expires, string secret)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expires,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateToken(IUsuario user)
    {
        var secretKey = _configuration["Jwt:SecretKey"];
        ArgumentException.ThrowIfNullOrWhiteSpace(secretKey);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim("Cpf", user.Cpf),
        };

        return GenerateTokenInternal(claims, DateTime.UtcNow.AddHours(8), secretKey);
    }
}
