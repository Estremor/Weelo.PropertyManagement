using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IOwnerAppService : IAppService
    {
        #region Contract
        Task SaveAsync(OwnerDto owner);
        #endregion
    }
}
