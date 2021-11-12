using Weelo.PropertyManagement.Domain.Base;
using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyTraceDomainService : IDomainService
    {
        #region Contract
        ActionResult RegisterTrace(PropertyTrace trace);
        #endregion
    }
}
