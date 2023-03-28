using Microsoft.AspNetCore.Identity;
using northwind_blazor.WebUI.Shared.Authorization;

namespace northwind_blazor.Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public Permissions Permissions { get; set; }
    }
}