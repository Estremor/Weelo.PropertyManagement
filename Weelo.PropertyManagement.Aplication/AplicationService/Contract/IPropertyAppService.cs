using System.Linq;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IPropertyAppService : IAppService
    {
        #region Contarct
        Task SavePropertyAsync(PropertyDataDto propertyDto);
        Task UpdatePropertyAsync(PropertyTraceDto traceDto);
        Task UpdatePriceAsync(PriceDto priceDto);
        IQueryable<PropertyReadDto> List();
        #endregion
    }
}
