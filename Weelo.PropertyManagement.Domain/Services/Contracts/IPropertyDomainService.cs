using System;
using Weelo.PropertyManagement.Domain.Base.Contract;
using Weelo.PropertyManagement.Domain.Entities;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyDomainService : IDomainService
    {
        #region Contract
        Property Save(Property property);
        Property UpdateProperty(Guid id, Property property);
        #endregion
    }
}
