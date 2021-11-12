using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

namespace Weelo.PropertyManagement.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        #region Fields
        private readonly ILoginAppService _loginAppService;
        #endregion

        #region C'tor
        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }
        #endregion

        #region Methods
        // GET api/<LoginController>/5
        [HttpGet]
        [Route(nameof(Get))]
        [AllowAnonymous]
        public async Task<UserDto> Get(string userName, string password)
        {
            return await _loginAppService.LoginUserAsync(userName, password);
        }
        #endregion

    }
}
