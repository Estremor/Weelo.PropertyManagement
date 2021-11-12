using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Weelo.PropertyManagement.Domain.Entities;

namespace Weelo.PropertyManagement.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DbContext>();
                var entity = context.Set<User>();
                if (!entity.Any())
                {
                    await entity.AddAsync(new User { UserName = "Weello.property", Password = "W3310" });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
