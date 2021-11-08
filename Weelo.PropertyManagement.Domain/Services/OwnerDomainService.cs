using System;
using System.Linq;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Domain.Services
{
    public class OwnerDomainService : DomainService, IOwnerDomainService
    {
        #region Fields
        private readonly IRepository<Owner> _ownerRepo;
        #endregion

        #region C'tor
        public OwnerDomainService(IRepository<Owner> ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
        #endregion

        #region Methods
        public RequestResultType Save(Owner owner)
        {
            if (!_ownerRepo.Entity.Any(x => x.Document == owner.Document))
            {
                Owner ownerResult = _ownerRepo.Insert(owner);
                return RequestResultType.SuccessResult;
            }
            return RequestResultType.AlreadyExistObjectResult;
        }
        #endregion
    }
}
