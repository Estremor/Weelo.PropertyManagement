using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.Configuration;
using Weelo.PropertyManagement.Api.ModelState;
using Microsoft.Extensions.DependencyInjection;
using Weelo.PropertyManagement.Aplication.Dtos;
using Weelo.PropertyManagement.Infrastructure.DI;
using Weelo.PropertyManagement.Infrastructure.Base;
using Weelo.PropertyManagement.Infrastructure.Middleware;
using System.Linq;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.Net.Http.Headers;

namespace Weelo.PropertyManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static IEdmModel GetModel()
        {
            ODataConventionModelBuilder builder = new();
            builder.EntitySet<PropertyReadDto>("PropertyData");
            return builder.GetEdmModel();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddOData();
            services.AddMvc(op => op.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Weelo.PropertyManagement.Api", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(Aplication.Automapper.AutoMapperProfile));

            #region FluentValidation
            services.AddControllers().AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblyContaining<OwnerDtoValidator>();
            });
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion

            AddFormatters(services);
            var dbSettings = new DbSettings();
            Configuration.Bind("DbSetting", dbSettings);
            services.AddSingleton(dbSettings);
            DependencyInjectionProfile.RegisterProfile(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weelo.PropertyManagement.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().OrderBy().Filter();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddFormatters(IServiceCollection services)
        {
            services.AddMvcCore(option =>
            {
                foreach (var outputFormatter in option.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }

                foreach (var inputFormatter in option.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }
    }
}
