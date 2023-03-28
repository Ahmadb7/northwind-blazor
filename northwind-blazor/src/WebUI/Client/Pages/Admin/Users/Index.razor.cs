using Microsoft.AspNetCore.Components;
using northwind_blazor.WebUI.Shared.AccessControl;

namespace northwind_blazor.WebUI.Client.Pages.Admin.Users
{
    public partial class Index
    {
        [Inject]
        public IUsersClient UsersClient { get; set; } = null!;

        public UsersVm? Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = await UsersClient.GetUsersAsync();
        }
    }
}