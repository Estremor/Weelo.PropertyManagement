using System.Threading.Tasks;
using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyImageDomainService : IDomainService
    {
        #region Contract
        Task<ActionResult> SaveImageAsync(PropertyImage image);
        #endregion
    }
}
