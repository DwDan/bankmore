using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BM.BuildingBlocks.Domain.Security;
using BM.BuildingBlocks.Infrastructure.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NSubstitute;

namespace BM.BuildingBlocks.Unit.Tests
{
    public class JwtTokenGeneratorTests
    {
        private const string SecretKey = "minha-chave-super-secreta-para-testes";

        [Fact(DisplayName = "Gerar Token Deve Retornar Jwt Valido")]
        [Trait("Autenticação", "JwtTokenGeneratorTests")]
        public void GerarToken_DeveRetornarJwtValido()
        {
            // Arrange
            var configuration = Substitute.For<IConfiguration>();
            configuration["Jwt:SecretKey"].Returns(SecretKey);

            var tokenGenerator = new JwtTokenGenerator(configuration);

            var user = Substitute.For<IUsuario>();
            var id = Guid.NewGuid();
            user.Id.Returns(id);
            user.Cpf.Returns("12345678910");

            // Act
            var token = tokenGenerator.GenerateToken(user);

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(token));

            var handler = new JwtSecurityTokenHandler();
            var principal = handler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey))
            }, out _);

            Assert.Equal(id.ToString(), principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Assert.Equal("12345678910", principal.FindFirst("Cpf")?.Value);
        }
    }
}