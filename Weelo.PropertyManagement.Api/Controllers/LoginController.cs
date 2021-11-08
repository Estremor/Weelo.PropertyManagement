using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<LoginController>/5
        [HttpGet]
        [Route(nameof(Get))]
        [AllowAnonymous]
        public UserDto Get(string userName, string password)
        {
            return _loginAppService.LoginUser(userName, password);
        }

    }
}
