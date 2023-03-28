using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using northwind_blazor.Application.Common.Services.Data;
using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.Infrastructure.Data;
using northwind_blazor.Infrastructure.Data.Interceptors;
using northwind_blazor.Infrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddClaimsPrincipalFactory<ApplicationUserClaimsPrincipalFactory>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
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