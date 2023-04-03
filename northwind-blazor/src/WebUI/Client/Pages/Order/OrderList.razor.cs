using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Customers.Commands.CreateCustomer;
using northwind_blazor.Application.Customers.Commands.UpdateCustomer;
using northwind_blazor.Application.Customers.Queries.GetCustomerDetail;
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

        private async Task OnEditModelSaving(GridEditModelSavingEventArgs e)
        {
            var editModel = (CustomerLookupDto)e.EditModel;
            var dataItem = e.IsNew ? new CustomerLookupDto() : (CustomerLookupDto)e.DataItem;

            dataItem.Id = editModel.Id;
            dataItem.Name = editModel.Name;

            if (e.IsNew)
            {
                Model.Customers.Add(dataItem as CustomerLookupDto);

                var cmd = new CreateCustomerCommand();
                cmd.Id = editModel.Id;
                cmd.CompanyName = editModel.Name;

                var customerDetail = await Http.GetFromJsonAsync<CustomerDetailVm>($"api/Customers/{editModel.Id}");

                if (customerDetail != null)
                {
                    cmd.Address = customerDetail.Address;
                    cmd.City = customerDetail.City;
                    cmd.ContactName = customerDetail.ContactName;
                    cmd.ContactTitle = customerDetail.ContactTitle;
                    cmd.Country = customerDetail.Country;
                    cmd.Fax = customerDetail.Fax;
                    cmd.Phone = customerDetail.Phone;
                    cmd.PostalCode = customerDetail.PostalCode;
                    cmd.Region = customerDetail.Region;
                }
                else
                {
                    cmd.Address = "";
                    cmd.City = "";
                    cmd.ContactName = "";
                    cmd.ContactTitle = "";
                    cmd.Country = "";
                    cmd.Fax = "";
                    cmd.Phone = "";
                    cmd.PostalCode = "";
                    cmd.Region = "";
                }

                await Http.PostAsJsonAsync<CreateCustomerCommand>($"api/Customers/{cmd.Id}", cmd, CancellationToken.None);

            }
            else
            {
                try
                {
                    var customerDetail = await Http.GetFromJsonAsync<CustomerDetailVm>($"api/Customers/{editModel.Id}");

                    if (customerDetail != null)
                    {
                        var cmd = new UpdateCustomerCommand();
                        cmd.Id = editModel.Id;
                        cmd.Address = customerDetail.Address;
                        cmd.City = customerDetail.City;
                        cmd.CompanyName = editModel.Name;
                        cmd.ContactName = customerDetail.ContactName;
                        cmd.ContactTitle = customerDetail.ContactTitle;
                        cmd.Country = customerDetail.Country;
                        cmd.Fax = customerDetail.Fax;
                        cmd.Phone = customerDetail.Phone;
                        cmd.PostalCode = customerDetail.PostalCode;
                        cmd.Region = customerDetail.Region;

                        await Http.PutAsJsonAsync<UpdateCustomerCommand>($"api/Customers/{cmd.Id}", cmd, CancellationToken.None);
                    }
                }
                catch (AccessTokenNotAvailableException exception)
                {
                    exception.Redirect();
                }
            }
        }
    }
}
