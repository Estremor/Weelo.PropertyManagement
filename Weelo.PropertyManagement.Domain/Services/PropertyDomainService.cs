using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Domain.Services
{
    public class PropertyDomainService : DomainService, IPropertyDomainService
    {
        #region Fileds
        private readonly IRepository<Property> _propertyRepo;
        private readonly IRepository<Owner> _ownerRepo;
        #endregion

        #region C'tor
        public PropertyDomainService(IRepository<Property> propertyRepo, IRepository<Owner> ownerRepo)
        {
            _propertyRepo = propertyRepo;
            _ownerRepo = ownerRepo;
        }
        #endregion

        #region Method
        public async Task<Property> SaveAsync(Property property)
        {
            ICollection<Property> entityResult = _propertyRepo.List(p => p.CodeInternal.Equals(property.CodeInternal));
            if (entityResult is not null && entityResult.Count > 0)
            {
                return null;
            }
            ICollection<Owner> ownerResult = _ownerRepo.List(o => o.IdOwner == property.IdOwner);
            if (ownerResult is null || ownerResult.Count == 0)
            {
                return null;
            }
            property.IdOwner = ownerResult.First().IdOwner;
            Property resultSave = await _propertyRepo.InsertAsync(property);
            return resultSave;
        }

        public async Task<Property> UpdatePropertyAsync(Property property)
        {
            var propertyEnity = _propertyRepo.List(x => x.CodeInternal == property.CodeInternal);
            if (propertyEnity is not null && propertyEnity.Count > 0)
            {
                if (_ownerRepo.Entity.Find(property.IdOwner) != null)
                {
                    Property propertyUp = propertyEnity.First();
                    propertyUp.Address = property.Address;
                    propertyUp.IdOwner = property.IdOwner;
                    propertyUp.Name = property.Name;
                    propertyUp.Price = property.Price;
                    propertyUp.Year = property.Year;
                    propertyUp = await _propertyRepo.UpdateAsync(propertyUp);
                    return propertyUp;
                }
            }
            return null;
        }
        public async Task<RequestResultType> UpdatePriceAsync(Property property)
        {
            var prop = _propertyRepo.List(x => x.CodeInternal == property.CodeInternal);
            if (prop == null || prop.Count == 0)
                return RequestResultType.ErrorResul;

            Property propertyForUpdate = prop.FirstOrDefault();
            propertyForUpdate.Price = property.Price;
            await _propertyRepo.UpdateAsync(propertyForUpdate);

            return RequestResultType.SuccessResult;
        }
        #endregion
    }
}
