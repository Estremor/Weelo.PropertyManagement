using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<UserDto> LoginUserAsync(string userName, string password)
        {
            ActionResult userResult = await _loginDomainService.FindUserAsync(new User { UserName = userName, Password = password });
            if (userResult.IsSuccessful)
            {
                var user = (User)userResult.Result;
                return new UserDto
                {
                    UserName = user.UserName,
                    Token = _loginDomainService.CreateToken(user)
                };
            }
            throw new RestException(HttpStatusCode.NotFound, new { Messages = userResult.ErrorMessage });
        }
        #endregion
    }
}
