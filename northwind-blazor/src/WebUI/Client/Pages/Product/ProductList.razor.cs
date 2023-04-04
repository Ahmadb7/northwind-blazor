using DevExpress.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Customers.Commands.UpdateCustomer;
using northwind_blazor.Application.Customers.Queries.GetCustomersList;
using northwind_blazor.Application.Products.Commands.CreateProduct;
using northwind_blazor.Application.Products.Commands.UpdateProduct;
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

        private async Task OnEditModelSaving(GridEditModelSavingEventArgs e)
        {
            var editModel = (ProductDto)e.EditModel;
            var dataItem = e.IsNew ? new ProductDto() : (ProductDto)e.DataItem;

            dataItem.ProductId = editModel.ProductId;
            dataItem.ProductCode = editModel.ProductCode;
            dataItem.ProductNameEn = editModel.ProductNameEn;
            dataItem.ProductNameFa = editModel.ProductNameFa;
            dataItem.CategoryId = editModel.CategoryId;
            dataItem.CategoryName = editModel.CategoryName;
            dataItem.Discontinued = editModel.Discontinued;
            dataItem.SupplierCompanyName = editModel.SupplierCompanyName;
            dataItem.SupplierId = editModel.SupplierId;
            dataItem.UnitPrice = editModel.UnitPrice;

            if (e.IsNew)
            {
                Model.Products.Add(dataItem as ProductDto);

                var cmd = new CreateProductCommand();
                cmd.CategoryId = editModel.CategoryId;
                cmd.Discontinued = editModel.Discontinued;
                cmd.ProductCode = editModel.ProductCode;
                cmd.ProductNameEn = editModel.ProductNameEn;
                cmd.ProductNameFa = editModel.ProductNameFa;
                cmd.SupplierId = editModel.SupplierId;
                cmd.UnitPrice = editModel.UnitPrice;

                await Http.PostAsJsonAsync<CreateProductCommand>($"api/Products", cmd, CancellationToken.None);
            }
            else
            {
                var cmd = new UpdateProductCommand();
                cmd.CategoryId = editModel.CategoryId;
                cmd.Discontinued = editModel.Discontinued;
                cmd.ProductId = editModel.ProductId;
                cmd.ProductCode = editModel.ProductCode;
                cmd.ProductNameEn = editModel.ProductNameEn;
                cmd.ProductNameFa = editModel.ProductNameFa;
                cmd.SupplierId = editModel.SupplierId;
                cmd.UnitPrice = editModel.UnitPrice;

                await Http.PutAsJsonAsync<UpdateProductCommand>($"api/Products", cmd, CancellationToken.None);

            }

        }
    }
}
