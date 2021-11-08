using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weelo.PropertyManagement.Domain.Base.Contract
{
    /// <summary>
    /// Define los atributos y métodos de un servicio de aplicación
    /// </summary>
    public interface IAppService
    {
        #region Properties

        /// <summary>
        /// Contexto de datos
        /// </summary>
        DbContext Context { get; }

        #endregion
    }
}
