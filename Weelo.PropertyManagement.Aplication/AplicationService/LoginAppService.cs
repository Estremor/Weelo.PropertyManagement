using Microsoft.EntityFrameworkCore;
using System;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.Errors;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Aplication.AplicationService
{
    public class LoginAppService : AppService, ILoginAppService
    {
        #region Fileds
        private readonly ILoginDomainService _loginDomainService;
        #endregion

        #region C´tor
        public LoginAppService(DbContext context) : base(context)
        {
            _loginDomainService = Context.GetDomainService<ILoginDomainService>();
        }
        #endregion
        #region Methods
        public UserDto LoginUser(string userName, string password)
        {
            User userResult = _loginDomainService.FindUser(new User { UserName = userName, Password = password });
            if (userResult is not null)
            {
                return new UserDto
                {
                    UserName = userResult.UserName,
                    Token = _loginDomainService.CreateToken(userResult)
                };
            }
            throw new RestException(System.Net.HttpStatusCode.NotFound, new { Messages = "Usuario no encontrado" });
        } 
        #endregion
    }
}
