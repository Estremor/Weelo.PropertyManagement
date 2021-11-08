using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface ILoginAppService : IAppService
    {
        #region Contract
        UserDto LoginUser(string userName, string password);
        #endregion
    }
}
