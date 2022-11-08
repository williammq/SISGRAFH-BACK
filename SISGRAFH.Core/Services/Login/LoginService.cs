using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SISGRAFH.Core.DTOs.Login;
using SISGRAFH.Core.Interfaces.Login;
using SISGRAFH.Infraestructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SISGRAFH.Core.Services.Login
{
    public class LoginService : ILoginService
    {
        private static IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public LoginService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<AuthUserToken> GetAuthorization(AuthUserInfo authInfo)
        {
            var user = await _unitOfWork.Usuario.GetUserByCredentials(authInfo);
            if(user == null)
            {
                return null;
            }
            return BuildToken(authInfo, user.Id);
        }

        private AuthUserToken BuildToken(AuthUserInfo userInfo, string iduser)//IList<string> roles
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.useremail),
                new Claim(ClaimTypes.Name, userInfo.useremail),
                new Claim("iduser", iduser),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //claims.Add(new Claim(ClaimTypes.Role, rol.id_rol));

            var key = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(8);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new AuthUserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
