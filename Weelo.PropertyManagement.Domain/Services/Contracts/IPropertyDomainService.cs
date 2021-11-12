using System.Threading.Tasks;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyDomainService : IDomainService
    {
        #region Contract
        Task<ActionResult> SaveAsync(Property property);
        Task<ActionResult> UpdatePropertyAsync(Property property);
        Task<ActionResult> UpdatePriceAsync(Property property);
        #endregion
    }
}
