using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Aplication.Errors;
using Weelo.PropertyManagement.Domain.Services.Contracts;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

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
        public async Task SaveAsync(OwnerDto ownerDto)
        {
            Owner owner = _mapper.Map<Owner>(ownerDto);
            var result = await _ownerDomainService.SaveAsync(owner);
            if (!result.IsSuccessful)
                throw new RestException(System.Net.HttpStatusCode.AlreadyReported, new { Messages = result.ErrorMessage });

            await Context.SaveChangesAsync();
        }
        #endregion
    }
}
