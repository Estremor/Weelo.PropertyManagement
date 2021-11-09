using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Weelo.PropertyManagement.Api.Filters;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;

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
        // GET: api/<OwnerController>
        [Authorize]
        [HttpGet]
        public IEnumerable<OwnerDto> Get()
        {
            return new List<OwnerDto>();
        }

        // POST api/<OwnerController>
        [HttpPost]
        [Authorize]
        [CustomValidation]
        public void Post(OwnerDto owner)
        {
            _ownerAppService.Save(owner);
        }
        #endregion
    }
}
