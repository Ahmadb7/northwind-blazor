using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Application.Common.Services.Data;
using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.Infrastructure;
using northwind_blazor.Infrastructure.Data;
using northwind_blazor.Infrastructure.Data.Interceptors;
using northwind_blazor.Infrastructure.Files;
using northwind_blazor.Infrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            services.AddDbContext<NorthwindDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddScoped<INorthwindDbContext>(sp =>
                sp.GetRequiredService<NorthwindDbContext>());

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<NorthwindDbContext>()
                .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, NorthwindDbContext>(options =>
                {
                    options.IdentityResources["openid"].UserClaims.Add("role");
                    options.ApiResources.Single().UserClaims.Add("role");
                    options.IdentityResources["openid"].UserClaims.Add("permissions");
                    options.ApiResources.Single().UserClaims.Add("permissions");
                });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
