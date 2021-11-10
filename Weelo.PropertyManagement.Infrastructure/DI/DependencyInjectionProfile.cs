using Microsoft.IdentityModel.Tokens;
using Weelo.PropertyManagement.Domain.Base;
using Microsoft.Extensions.DependencyInjection;
using Weelo.PropertyManagement.Domain.Services;
using Weelo.PropertyManagement.Domain.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Weelo.PropertyManagement.Infrastructure.Repository;
using Weelo.PropertyManagement.Domain.Services.Contracts;
using Weelo.PropertyManagement.Aplication.AplicationService;
using Weelo.PropertyManagement.Aplication.AplicationService.Contract;

namespace Weelo.PropertyManagement.Infrastructure.DI
{
    /// <summary>
    /// Contiene la Configuracion de la injeccion de dependencias
    /// </summary>
    public static class DependencyInjectionProfile
    {
        /// <summary>
        /// Registra Las dependencias, como se resuelven
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterProfile(IServiceCollection services)
        {
            #region Context
            DBExtensions.services = services;
            /*Registramos el contexto*/
            services.AddTransient<Microsoft.EntityFrameworkCore.DbContext, DataPersistence.WeeloPropertyDbContext>(s =>
            {
                Base.DbSettings settings = s.GetService<Base.DbSettings>();
                return new DataPersistence.WeeloPropertyDbContext(settings);
            });
            #endregion

            #region Authentication
            SymmetricSecurityKey key = new(System.Text.Encoding.UTF8.GetBytes("Weelo.Property.Management"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                };
            });
            #endregion

            #region Repositories
            /*Resolvemos los repositorios Genericos*/
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Application

            services.AddTransient<IOwnerAppService, OwnerAppService>();
            services.AddTransient<ILoginAppService, LoginAppService>();
            services.AddTransient<IPropertyAppService, PropertyAppService>();
            services.AddTransient<IPropertyImageAppService, PropertyImageAppService>();
            #endregion

            #region Domain
            services.AddTransient<IOwnerDomainService, OwnerDomainService>();
            services.AddTransient<ILoginDomainService, LoginDomainService>();
            services.AddTransient<IPropertyDomainService, PropertyDomainService>();
            services.AddTransient<IPropertyImageDomainService, PropertyImageDomainService>();
            services.AddTransient<IPropertyTraceDomainService, PropertyTraceDomainService>();
            #endregion
        }
    }
}
