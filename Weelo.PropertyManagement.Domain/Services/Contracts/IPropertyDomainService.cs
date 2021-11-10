using System.Threading.Tasks;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyDomainService : IDomainService
    {
        #region Contract
        Task<Property> SaveAsync(Property property);
        Task<Property> UpdatePropertyAsync(Property property);
        Task<RequestResultType> UpdatePriceAsync(Property property);
        #endregion
    }
}
