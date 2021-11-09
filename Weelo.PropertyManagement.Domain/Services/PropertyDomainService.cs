using System.Linq;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;
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
        public Property Save(Property property)
        {
            Property entityResult = _propertyRepo.List(p => p.CodeInternal.Equals(property.CodeInternal)).FirstOrDefault();
            if (entityResult is not null)
            {
                return null;
            }
            Owner ownerResult = _ownerRepo.List(o => o.IdOwner == property.IdOwner).FirstOrDefault();
            if (ownerResult is null)
            {
                return null;
            }
            property.IdOwner = ownerResult.IdOwner;
            Property resultSave = _propertyRepo.Insert(property);
            return resultSave;
        }

        public Property UpdateProperty(Property property)
        {
            Property propertyEnity = _propertyRepo.List(x => x.CodeInternal == property.CodeInternal).FirstOrDefault();
            if (propertyEnity is not null)
            {
                if (_ownerRepo.Entity.Find(property.IdOwner) != null)
                {
                    propertyEnity.Address = property.Address;
                    propertyEnity.IdOwner = property.IdOwner;
                    propertyEnity.Name = property.Name;
                    propertyEnity.Price = property.Price;
                    propertyEnity.Year = property.Year;
                    return _propertyRepo.Update(propertyEnity);
                }
            }
            return null;
        }

        public RequestResultType UpdatePrice(Property property)
        {
            Property prop = _propertyRepo.List(x => x.CodeInternal == property.CodeInternal).FirstOrDefault();
            if (prop == null)
                return RequestResultType.ErrorResul;
            prop.Price = property.Price;
            _propertyRepo.Update(prop);
            return RequestResultType.SuccessResult;
        }
        #endregion
    }
}
