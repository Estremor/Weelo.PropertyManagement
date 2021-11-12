using System.Threading.Tasks;
using Weelo.PropertyManagement.Domain.Base;
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
        public async Task<ActionResult> SaveAsync(Owner owner)
        {
            if (_ownerRepo.List(x => x.Document == owner.Document).Count <= 0)
            {
                Owner ownerResult = await _ownerRepo.InsertAsync(owner);
                return new ActionResult { IsSuccessful = true };
            }
            return new ActionResult { IsSuccessful = false, ErrorMessage = "ya se registro un owner con ese documento" };
        }
        #endregion
    }
}
