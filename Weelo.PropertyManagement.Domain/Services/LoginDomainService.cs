using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Domain.Services
{
    public class LoginDomainService : DomainService, ILoginDomainService
    {
        #region Fields
        private readonly IRepository<User> _userRepository;
        private readonly string SecurityKey;
        #endregion

        #region C'tor
        public LoginDomainService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
            SecurityKey = "Weelo.Property.Management";
        }
        #endregion

        #region Methods
        public async Task<ActionResult> FindUserAsync(User user)
        {
            var userEntity = await _userRepository.ListAsync(x => x.UserName == user.UserName && x.Password == user.Password);
            return new ActionResult { IsSuccessful = true, Result = userEntity.FirstOrDefault() };
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };
            SymmetricSecurityKey key = new(System.Text.Encoding.UTF8.GetBytes(SecurityKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256Signature);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(6),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
