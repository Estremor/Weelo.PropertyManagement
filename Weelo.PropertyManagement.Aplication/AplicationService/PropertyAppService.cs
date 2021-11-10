using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task SavePropertyAsync(PropertyDataDto propertyDto)
        {
            Property property = _mapper.Map<Property>(propertyDto);
            property.IdOwner = _ownerRepo.Entity.FirstOrDefault(o => o.Document == propertyDto.OwnerDocument)?.IdOwner ?? Guid.Empty;
            property = await _propertyDomainServ.SaveAsync(property);
            if (property == null)
            {
                throw new RestException(System.Net.HttpStatusCode.AlreadyReported, new { Messages = "Ocurrio un error al guardar las propiedad intentalo nuevamente" });
            }

            //registramos las imagenes
            List<PropertyImage> images = _mapper.Map<List<PropertyImage>>(propertyDto.PropertyImages);
            foreach (PropertyImage item in images)
            {
                item.IdProperty = property.IdProperty;
                RequestResultType result = await _propertyImageDomainServ.SaveImageAsync(item);
                if (result == RequestResultType.ErrorResul)
                {
                    throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { Messages = "Ocurrio un error al guardar las imagenes intentalo nuevamente" });
                }
            }
            await Context.SaveChangesAsync();
        }
        public async Task UpdatePropertyAsync(PropertyTraceDto traceDto)
        {
            //mapeamos la entidad property y buscamos el id
            Property property = _mapper.Map<Property>(traceDto);
            property.IdOwner = _ownerRepo.List(x => x.Document == traceDto.OwnerDocument).FirstOrDefault()?.IdOwner ?? Guid.Empty;
            property = await _propertyDomainServ.UpdatePropertyAsync(property);
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

            await Context.SaveChangesAsync();
        }
        public async Task UpdatePriceAsync(PriceDto priceDto)
        {
            var result = await _propertyDomainServ.UpdatePriceAsync(new Property { CodeInternal = priceDto.InernalCode, Price = priceDto.Price });
            if (result == RequestResultType.ErrorResul)
                throw new RestException(System.Net.HttpStatusCode.NotFound, new { Messages = $"Ocurrio un error al realizar la actualizacion del precio, el codigo {priceDto.InernalCode} no existe" });
            await Context.SaveChangesAsync();
        }

        /// <summary>
        /// Utilizamos Odata protocolo injectamos el repository directo a la capa de aplicacion 
        /// por que no manejamos logica de negocio
        /// </summary>
        /// <returns>entidades segun los filtros</returns>
        public IQueryable<PropertyReadDto> List()
        {
            var result = _propertyRepo.ListByQuery();
            return _mapper.ProjectTo<PropertyReadDto>(result);
        }
        #endregion
    }
}
