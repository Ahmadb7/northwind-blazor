using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.Infrastructure.Data;
using static northwind_blazor.Application.SubcutaneousTests.Testing;

namespace northwind_blazor.Application.SubcutaneousTests
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                configurationBuilder.AddConfiguration(integrationConfig);
            });

            builder.ConfigureServices((builder, services) =>
            {
                services
                    .Remove<ICurrentUser>()
                    .AddTransient(provider => Mock.Of<ICurrentUser>(s =>
                        s.UserId == GetCurrentUserId()));

                services
                    .Remove<DbContextOptions<NorthwindDbContext>>()
                    .AddDbContext<NorthwindDbContext>((sp, options) =>
                        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                            builder => builder.MigrationsAssembly(typeof(NorthwindDbContext).Assembly.FullName)));
            });
        }
    }
}
