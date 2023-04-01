using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Customers.Queries.GetCustomersList;
using System.Net.Http.Json;

namespace northwind_blazor.WebUI.Client.Pages.Customer
{
    public partial class CustomerList
    {
        public CustomersListVm Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var mod = await Http.GetFromJsonAsync<CustomersListVm>("api/Customers");
                Model = mod;
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }
    }
}
