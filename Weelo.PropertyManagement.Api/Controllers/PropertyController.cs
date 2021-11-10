using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Api.Filters;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;

namespace Weelo.PropertyManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ODataController
    {
        #region Fields
        private readonly IPropertyAppService _propertyAppService;
        #endregion

        #region C'tor
        public PropertyController(IPropertyAppService propertyAppService)
        {
            _propertyAppService = propertyAppService;
        }
        #endregion


        #region Methods
        // GET: api/<PropertyController>
        [HttpGet]
        [EnableQuery]
        public IEnumerable<PropertyReadDto> Get()
        {
            return _propertyAppService.List();
        }

        // POST api/<PropertyController>
        [HttpPost]
        [Authorize]
        [CustomValidation]
        public async Task<IActionResult> Post(PropertyDataDto propertyData)
        {
            await _propertyAppService.SavePropertyAsync(propertyData);
            return Ok(propertyData);
        }

        // PUT api/<PropertyController>/5
        [HttpPut]
        [Authorize]
        [CustomValidation]
        public async Task<IActionResult> Put(PropertyTraceDto propertyTrace)
        {
            await _propertyAppService.UpdatePropertyAsync(propertyTrace);
            return Ok();
        }

        [HttpPatch]
        [Authorize]
        [CustomValidation]
        public async Task<IActionResult> UpdatePrice(PriceDto priceDto)
        {
            await _propertyAppService.UpdatePriceAsync(priceDto);
            return Ok();
        }
        #endregion
    }
}
