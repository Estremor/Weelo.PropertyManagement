using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weelo.PropertyManagement.Api.Filters;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

namespace Weelo.PropertyManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        #region Fields
        private readonly IOwnerAppService _ownerAppService;
        #endregion

        #region C´tor
        public OwnerController(IOwnerAppService ownerAppService)
        {
            _ownerAppService = ownerAppService;
        }
        #endregion

        #region Methods

        // POST api/<OwnerController>
        [HttpPost]
        [Authorize]
        [CustomValidation]
        public async Task<IActionResult> Post(OwnerDto owner)
        {
            await _ownerAppService.SaveAsync(owner);
            return Ok();
        }
        #endregion
    }
}
