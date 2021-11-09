using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region servicios de dominio
        private readonly IPropertyDomainService _propertyDomainServ;
        private readonly IPropertyImageDomainService _propertyImageDomainServ;
        private readonly IPropertyTraceDomainService _traceDomain;
        #endregion

        #region Repository
        private readonly IRepository<Owner> _ownerRepo;
        private readonly IRepository<Property> _propertyRepo;
        #endregion

        private readonly IMapper _mapper;
        #endregion

        #region C'tor
        public PropertyAppService(DbContext context, IMapper mapper) : base(context)
        {
            _propertyDomainServ = Context.GetDomainService<IPropertyDomainService>();
            _propertyImageDomainServ = Context.GetDomainService<IPropertyImageDomainService>();
            _ownerRepo = Context.GetRepository<IRepository<Owner>>();
            _propertyRepo = Context.GetRepository<IRepository<Property>>();
            _mapper = mapper;
            _traceDomain = Context.GetDomainService<IPropertyTraceDomainService>();
        }
        #endregion

        #region Methods
        public void SaveProperty(PropertyDataDto propertyDto)
        {
            Property property = _mapper.Map<Property>(propertyDto);
            property.IdOwner = _ownerRepo.Entity.FirstOrDefault(o => o.Document == propertyDto.OwnerDocument)?.IdOwner ?? Guid.Empty;
            property = _propertyDomainServ.Save(property);
            if (property == null)
            {
                throw new RestException(System.Net.HttpStatusCode.AlreadyReported, new { Messages = "Ocurrio un error al guardar las propiedad intentalo nuevamente" });
            }

            //registramos las imagenes
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

        public void UpdateProperty(PropertyTraceDto traceDto)
        {
            //mapeamos la entidad property y buscamos el id
            Property property = _mapper.Map<Property>(traceDto);
            property.IdOwner = _ownerRepo.List(x => x.Document == traceDto.OwnerDocument).FirstOrDefault()?.IdOwner ?? Guid.Empty;
            property = _propertyDomainServ.UpdateProperty(property);
            if (property is null)
            {
                throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { Messages = "Ocurrio un error al actualizar la propiedad, intentalo nuevamente" });
            }

            //aseguramos que el owner exista
            PropertyTrace propertyTrace = _mapper.Map<PropertyTrace>(traceDto);
            propertyTrace.IdProperty = property.IdProperty;
            propertyTrace.Name = _ownerRepo.Entity.Find(property.IdOwner)?.Name ?? string.Empty;

            if (string.IsNullOrWhiteSpace(propertyTrace.Name))
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { Messages = "No se encontro el Owner ingresado" });
            }

            var result = _traceDomain.RegisterTrace(propertyTrace);
            if (result == RequestResultType.ErrorResul)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { Messages = "Ocurrio un error al realizar la actualizacion" });
            }

            Context.SaveChanges();
        }
        public void UpdatePrice(PriceDto priceDto)
        {
            var result = _propertyDomainServ.UpdatePrice(new Property { CodeInternal = priceDto.InernalCode, Price = priceDto.Price });
            if (result == RequestResultType.ErrorResul)
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { Messages = $"Ocurrio un error al realizar la actualizacion del precio, el codigo {priceDto.InernalCode} no existe" });
            Context.SaveChanges();
        }
        public IQueryable<PropertyReadDto> List()
        {
            var result = _propertyRepo.ListByQuery();
            return _mapper.ProjectTo<PropertyReadDto>(result);
        }
        #endregion
    }
}
