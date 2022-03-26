using Domain.CustomEntities;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUsuarioRepository repository;
        private readonly IPasswordService passwordService;
        private readonly AuthOptions options;

        public TokenService(
            IUsuarioRepository repository,
            IPasswordService passwordService,
            IOptions<AuthOptions> options)
        {
            this.repository = repository;
            this.passwordService = passwordService;
            this.options = options.Value;
        }

        public async Task<(bool, Usuario)> IsValidUser(Usuario login)
        {
            var user = await repository.GetByLogin(login.Correo);
            if (user == null) throw new ArgumentException("El usuario especificado no existe", nameof(login));
            var isvalid = passwordService.CheckPass(user.Contraseña, login.Contraseña);
            return (isvalid, user);
        }

        public LoginResult GetToken(Usuario auth)
        {
            //Header
            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, auth.Nombre),
                new Claim(ClaimTypes.Email, auth.Correo),
                new Claim(ClaimTypes.Role, auth.CodigoRol),
            };

            //Payload
            var payload = new JwtPayload
            (
                options.Issuer,
                options.Audience,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(options.ValidTime)
            );

            var token = new JwtSecurityToken(header, payload);
            return new LoginResult
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiryDate = token.ValidTo
            };
        }
    }
}
