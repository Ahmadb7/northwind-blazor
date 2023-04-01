using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Customers.Queries.GetCustomersList;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.WeatherForecasts;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace northwind_blazor.WebUI.Client.Pages.Customer
{
    public partial class CustomerList
    {
        public CustomersListVm Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Http.GetFromJsonAsync<CustomersListVm>("api/Customers");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private void OnDataItemDeleting(GridDataItemDeletingEventArgs e)
        {
            Model.Customers.Remove(e.DataItem as CustomerLookupDto);
        }

        private void OnEditModelSaving(GridEditModelSavingEventArgs e)
        {
            var editModel = (CustomerLookupDto)e.EditModel;
            var dataItem = e.IsNew ? new CustomerLookupDto() : (CustomerLookupDto)e.DataItem;

            dataItem.Id = editModel.Id;
            dataItem.Name = editModel.Name;

            if (e.IsNew)
                Model.Customers.Add(dataItem as CustomerLookupDto);
        }
    }
}
