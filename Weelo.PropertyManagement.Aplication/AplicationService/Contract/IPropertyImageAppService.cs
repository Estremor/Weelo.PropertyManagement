using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IPropertyImageAppService : IAppService
    {
        #region Contract
        void AddImgeToProperty(ImageDto image);
        #endregion
    }
}
