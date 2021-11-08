using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Domain.Base.Enum;

namespace Weelo.PropertyManagement.Infrastructure.Base
{
    /// <summary>
    /// Context Base
    /// </summary>
    public abstract class DbContextBase : DbContext
    {
        #region Properties
        /// <summary>
        /// Obtiene el objeto de configuración del contexto
        /// </summary>
        protected DbSettings DbSettings { get; private set; }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="dbSettings">Objeto de configuración del contexto</param>
        public DbContextBase(DbSettings dbSettings) : base()
        {
            DbSettings = dbSettings;
            DbSettings.ConnectionString = DbSettings.ConnectionString;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Aqui se usar el proveedor de conexion que esté configurado
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (DbSettings.Provider)
                {
                    case SupportedProvider.SqlServer:
                        optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
                        break;
                    default:
                        optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
                        break;
                }
            }
        }

        #endregion
    }
}
