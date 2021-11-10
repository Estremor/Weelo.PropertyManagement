﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Api.Filters;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;

namespace Weelo.PropertyManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        #region Fields
        private readonly IPropertyImageAppService _imageAppService;
        #endregion

        #region C'tor
        public ImageController(IPropertyImageAppService imageAppService)
        {
            _imageAppService = imageAppService;
        }
        #endregion

        #region Methods
        // POST api/<ImageController>
        [HttpPost]
        [Authorize]
        [CustomValidation]
        public async Task Post(ImageDto image)
        {
            await _imageAppService.AddImgeToPropertyAsync(image);
        }
        #endregion
    }
}
