using Microsoft.EntityFrameworkCore;
using Weelo.PropertyManagement.Infrastructure.Base;
using Weelo.PropertyManagement.Infrastructure.DataPersistence.EntitiesConfig;

namespace Weelo.PropertyManagement.Infrastructure.DataPersistence
{
    public partial class WeeloPropertyDbContext : DbContextBase
    {
        #region C'tor
        /// <summary>
        /// Inicia el contexto de Datos
        /// </summary>
        /// <param name="dbSettings"></param>
        public WeeloPropertyDbContext(DbSettings dbSettings) : base(dbSettings)
        {
            DbSettings.ConnectionString = dbSettings.ConnectionString;
            Database.EnsureCreated();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Se usa la configuracion 
        /// </summary>
        /// <param name="dbContextOptionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
            }
        }

        /// <summary>
        /// Aplica la configuracion
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyImageConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyTraceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
