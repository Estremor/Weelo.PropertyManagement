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
    public class OwnerAppService : AppService, IOwnerAppService
    {
        #region Fields
        private readonly IOwnerDomainService _ownerDomainService;
        private readonly IMapper _mapper;
        #endregion

        #region C'tor
        public OwnerAppService(DbContext context, IMapper mapper) : base(context)
        {
            _ownerDomainService = Context.GetDomainService<IOwnerDomainService>();
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public void Save(OwnerDto ownerDto)
        {
            Owner owner = _mapper.Map<Owner>(ownerDto);
            var result = _ownerDomainService.Save(owner);

            if (result == RequestResultType.AlreadyExistObjectResult)
                throw new RestException(System.Net.HttpStatusCode.AlreadyReported, new { Messages = "Propietario ya existe" });
            if (result == RequestResultType.ErrorResul)
                throw new RestException(System.Net.HttpStatusCode.InternalServerError, new { Messages = "Ocurrio un error intentalo nuevamente" });
            Context.SaveChanges();
        } 
        #endregion
    }
}
