using System.Linq;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IPropertyAppService : IAppService
    {
        #region Contarct
        void SaveProperty(PropertyDataDto propertyDto);
        void UpdateProperty(PropertyTraceDto traceDto);
        void UpdatePrice(PriceDto priceDto);
        IQueryable<PropertyReadDto> List();
        #endregion
    }
}
