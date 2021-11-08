using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.Errors;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Base.Enum;
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
        public void AddImgeToProperty(ImageDto image)
        {
            PropertyImage entity = _mapper.Map<PropertyImage>(image);
            RequestResultType result = _propertyImageDomainServ.SaveImage(entity);
            if (result == RequestResultType.ErrorResul)
                throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { Messages = "Ocurrio un error al guardar la imagen intentalo nuevamente" });
        }
        #endregion
    }
}
