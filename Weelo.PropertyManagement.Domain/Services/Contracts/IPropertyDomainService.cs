using Weelo.PropertyManagement.Domain.Base.Contract;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Entities;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyDomainService : IDomainService
    {
        #region Contract
        Property Save(Property property);
        Property UpdateProperty(Property property);
        RequestResultType UpdatePrice(Property property);
        #endregion
    }
}
