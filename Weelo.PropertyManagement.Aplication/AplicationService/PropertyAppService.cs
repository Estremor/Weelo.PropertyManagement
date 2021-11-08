using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Aplication.Errors;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Aplication.AplicationService
{
    public class PropertyAppService : AppService, IPropertyAppService
    {
        #region Fields
        private readonly IPropertyDomainService _propertyDomainServ;
        private readonly IPropertyImageDomainService _propertyImageDomainServ;
        private readonly IRepository<Owner> _ownerRepo;
        private readonly IMapper _mapper;
        #endregion

        #region C'tor
        public PropertyAppService(DbContext context, IMapper mapper) : base(context)
        {
            _propertyDomainServ = Context.GetDomainService<IPropertyDomainService>();
            _propertyImageDomainServ = Context.GetDomainService<IPropertyImageDomainService>();
            _ownerRepo = Context.GetRepository<IRepository<Owner>>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public void SaveProperty(PropertyDataDto propertyDto)
        {
            Property property = _mapper.Map<Property>(propertyDto);
            property.IdOwner = _ownerRepo.Entity.FirstOrDefault(o => o.Document == propertyDto.OwnerDocument)?.IdOwner ?? Guid.Empty;
            property = _propertyDomainServ.Save(property);

            List<PropertyImage> images = _mapper.Map<List<PropertyImage>>(propertyDto.PropertyImages);
            foreach (PropertyImage item in images)
            {
                item.IdProperty = property.IdProperty;
                RequestResultType result = _propertyImageDomainServ.SaveImage(item);
                if (result == RequestResultType.ErrorResul)
                {
                    throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { Messages = "Ocurrio un error al guardar las imagenes intentalo nuevamente" });
                }
            }
            Context.SaveChanges();
        }

        public void UpdateProperty()
        {

        }
        #endregion
    }
}
