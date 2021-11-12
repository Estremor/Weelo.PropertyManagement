using System;
using System.Net;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Aplication.Errors;
using Weelo.PropertyManagement.Domain.Services.Contracts;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;
using Weelo.PropertyManagement.Domain.IRepository;

namespace Weelo.PropertyManagement.Aplication.AplicationService
{
    public class PropertyImageAppService : AppService, IPropertyImageAppService
    {
        #region Fields
        private readonly IPropertyImageDomainService _propertyImageDomainServ;
        private readonly IRepository<Property> _propertyRepo;
        private readonly IMapper _mapper;
        #endregion

        #region C´tor
        public PropertyImageAppService(DbContext context, IMapper mapper) : base(context)
        {
            _propertyImageDomainServ = Context.GetDomainService<IPropertyImageDomainService>();
            _propertyRepo = Context.GetRepository<IRepository<Property>>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task AddImgeToPropertyAsync(ImageDto image)
        {
            PropertyImage entity = _mapper.Map<PropertyImage>(image);
            entity.IdProperty = _propertyRepo.List(x => x.CodeInternal == image.InernalCode)?.FirstOrDefault().IdProperty ?? Guid.Empty;
            ActionResult result = await _propertyImageDomainServ.SaveImageAsync(entity);

            if (!result.IsSuccessful)
                throw new RestException(HttpStatusCode.InternalServerError, new { Messages = result.ErrorMessage });
            await Context.SaveChangesAsync();
        }
        #endregion
    }
}
