using System;
using System.Linq;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.IRepository;
using Weelo.PropertyManagement.Domain.Services.Contracts;

namespace Weelo.PropertyManagement.Domain.Services
{
    public class PropertyDomainService : DomainService, IPropertyDomainService
    {
        #region Fileds
        private readonly IRepository<Property> _PropertyRepo;
        private readonly IRepository<Owner> _ownerRepo;
        #endregion

        #region C'tor
        public PropertyDomainService(IRepository<Property> propertyRepo, IRepository<Owner> ownerRepo)
        {
            _PropertyRepo = propertyRepo;
            _ownerRepo = ownerRepo;
        }
        #endregion

        #region Method
        public Property Save(Property property)
        {
            Property entityResult = _PropertyRepo.List(p => p.CodeInternal.Equals(property.CodeInternal)).FirstOrDefault();
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
            Property resultSave = _PropertyRepo.Insert(property);
            return resultSave;
        }

        public Property UpdateProperty(Guid id, Property property)
        {
            Property propertyEnity = _PropertyRepo.Entity.Find(id);
            if (propertyEnity is not null)
            {
                propertyEnity.Address = property.Address;
                propertyEnity.IdOwner = property.IdOwner;
                propertyEnity.Name = property.Name;
                propertyEnity.Price = property.Price;
                propertyEnity.Year = property.Year;
                return _PropertyRepo.Insert(propertyEnity);
            }
            return null;
        }
        #endregion
    }
}
