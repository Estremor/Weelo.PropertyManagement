using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.Errors;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Aplication.AplicationService
{
    public class PropertyImageAppService : AppService, IPropertyImageAppService
    {
        #region Fields
        private readonly IPropertyImageDomainService _propertyImageDomainServ;
        private readonly IMapper _mapper;
        #endregion

        #region C´tor
        public PropertyImageAppService(DbContext context, IMapper mapper) : base(context)
        {
            _propertyImageDomainServ = Context.GetDomainService<IPropertyImageDomainService>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task AddImgeToPropertyAsync(ImageDto image)
        {
            PropertyImage entity = _mapper.Map<PropertyImage>(image);
            ActionResult result = await _propertyImageDomainServ.SaveImageAsync(entity);
            if (!result.IsSuccessful)
                throw new RestException(HttpStatusCode.InternalServerError, new { Messages = result.ErrorMessage });
            await Context.SaveChangesAsync();
        }
        #endregion
    }
}
