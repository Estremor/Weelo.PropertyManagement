using Weelo.PropertyManagement.Domain.Entities;
using Weelo.PropertyManagement.Domain.Base.Enum;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Domain.Services.Contracts
{
    public interface IPropertyTraceDomainService : IDomainService
    {
        #region Contract
        RequestResultType RegisterTrace(PropertyTrace trace);
        #endregion
    }
}
