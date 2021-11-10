using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IPropertyImageAppService : IAppService
    {
        #region Contract
        Task AddImgeToPropertyAsync(ImageDto image);
        #endregion
    }
}
