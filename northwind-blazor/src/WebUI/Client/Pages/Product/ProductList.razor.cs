using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Customers.Queries.GetCustomersList;
using northwind_blazor.Application.Products.Queries.GetProductsList;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.WeatherForecasts;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace northwind_blazor.WebUI.Client.Pages.Product
{
    public partial class ProductList
    {
        public ProductsListVm Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Http.GetFromJsonAsync<ProductsListVm>("api/Products");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        private void OnDataItemDeleting(GridDataItemDeletingEventArgs e)
        {
            Model.Products.Remove(e.DataItem as ProductDto);
        }

        private void OnEditModelSaving(GridEditModelSavingEventArgs e)
        {
            var editModel = (ProductDto)e.EditModel;
            var dataItem = e.IsNew ? new ProductDto() : (ProductDto)e.DataItem;

            dataItem.ProductId = editModel.ProductId;
            dataItem.ProductName = editModel.ProductName;
            dataItem.CategoryId = editModel.CategoryId;
            dataItem.CategoryName = editModel.CategoryName;
            dataItem.Discontinued = editModel.Discontinued;
            dataItem.SupplierCompanyName = editModel.SupplierCompanyName;
            dataItem.SupplierId = editModel.SupplierId;
            dataItem.UnitPrice = editModel.UnitPrice;

            if (e.IsNew)
                Model.Products.Add(dataItem as ProductDto);
        }
    }
}
