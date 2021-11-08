using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Weelo.PropertyManagement.Api.Filters;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OwnerController>
        [HttpPost]
        //[Authorize]
        [CustomValidation]
        public void Post(OwnerDto owner)
        {
            _ownerAppService.Save(owner);
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
