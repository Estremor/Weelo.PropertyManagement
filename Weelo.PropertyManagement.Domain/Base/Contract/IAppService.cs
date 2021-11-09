using Microsoft.EntityFrameworkCore;

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
