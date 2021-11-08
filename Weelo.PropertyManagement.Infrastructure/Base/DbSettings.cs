using Weelo.PropertyManagement.Domain.Base.Enum;

namespace Weelo.PropertyManagement.Infrastructure.Base
{
    /// <summary>
    /// Encapsula las propiedades de configuración de una
    /// conexión a una base de datos Sql
    /// </summary>
    public sealed class DbSettings
    {
        #region Properties

        /// <summary>
        /// Obtiene o asigna la cadena de conexión a la base de datos Sql
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Obtiene o asigna el tipo de proveedor Sql
        /// </summary>
        public SupportedProvider Provider { get; set; }

        #endregion
    }
}
