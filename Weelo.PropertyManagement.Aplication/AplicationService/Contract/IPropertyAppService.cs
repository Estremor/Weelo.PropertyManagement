using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Domain.Base.Contract;

namespace Weelo.PropertyManagement.Aplication.AplicationService.Contract
{
    public interface IPropertyAppService : IAppService
    {
        #region Contarct
        void SaveProperty(PropertyDataDto propertyDto);
        #endregion
    }
}
