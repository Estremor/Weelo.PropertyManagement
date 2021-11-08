using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IOwnerAppService : IAppService
    {
        #region Contract
        void Save(OwnerDto owner);
        #endregion
    }
}
