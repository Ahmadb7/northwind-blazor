using DevExpress.Blazor;
using DevExpress.Portable;
using MediatR;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Mvc;
using northwind_blazor.Application.Orders.Commands.UpsertOrder;
using northwind_blazor.Application.Orders.Queries.GetOrderDetail;
using northwind_blazor.Application.Orders.Queries.GetOrdersList;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.WeatherForecasts;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace northwind_blazor.WebUI.Client.Pages.Order
{
    public partial class OrderList
    {
        IGrid grid { get; set; }
        bool AutoCollapseDetailRow { get; set; }

        public OrdersListVm Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Model = await Http.GetFromJsonAsync<OrdersListVm>("api/orders");
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                grid?.ExpandDetailRow(0);
            }
        }

        void AutoCollapseDetailRow_Changed(bool newValue)
        {
            AutoCollapseDetailRow = newValue;
            if (newValue)
            {
                grid.BeginUpdate();
                grid.CollapseAllDetailRows();
                grid.ExpandDetailRow(0);
                grid.EndUpdate();
            }
        }

        private void OnDataItemDeleting(GridDataItemDeletingEventArgs e)
        {
            Model.Orders.Remove(e.DataItem as OrderLookupDto);
        }

        private async Task OnEditModelSaving(GridEditModelSavingEventArgs e)
        {
            var editModel = (OrderLookupDto)e.EditModel;
            var dataItem = e.IsNew ? new OrderLookupDto() : (OrderLookupDto)e.DataItem;

            dataItem.CustomerId = editModel.CustomerId;
            dataItem.EmployeeId = editModel.EmployeeId;
            dataItem.Freight = editModel.Freight;
            dataItem.OrderDate = editModel.OrderDate;
            dataItem.RequiredDate = editModel.RequiredDate;
            dataItem.ShipAddress = editModel.ShipAddress;
            dataItem.ShipCity = editModel.ShipCity;
            dataItem.ShipCountry = editModel.ShipCountry;
            dataItem.ShipName = editModel.ShipName;
            dataItem.ShippedDate = editModel.ShippedDate;
            dataItem.ShipPostalCode = editModel.ShipPostalCode;
            dataItem.ShipRegion = editModel.ShipRegion;
            dataItem.ShipVia = editModel.ShipVia;

            if (e.IsNew)
            {
                Model.Orders.Add(dataItem as OrderLookupDto);

                var cmd = new UpsertOrderCommand();
                cmd.CustomerId = editModel.CustomerId;
                cmd.EmployeeId = editModel.EmployeeId;
                cmd.Freight = editModel.Freight;
                cmd.OrderDate = editModel.OrderDate;
                cmd.RequiredDate = editModel.RequiredDate;
                cmd.ShipAddress = editModel.ShipAddress;
                cmd.ShipCity = editModel.ShipCity;
                cmd.ShipCountry = editModel.ShipCountry;
                cmd.ShipName = editModel.ShipName;
                cmd.ShippedDate = editModel.ShippedDate;
                cmd.ShipPostalCode = editModel.ShipPostalCode;
                cmd.ShipRegion = editModel.ShipRegion;
                cmd.ShipVia = editModel.ShipVia;

                var orderDetail = await Http.GetFromJsonAsync<OrderDetailVm>($"api/orders/{editModel.OrderId}");

                await Http.PostAsJsonAsync<UpsertOrderCommand>($"api/orders/{cmd.OrderId}", cmd, CancellationToken.None);

            }
            else
            {
                try
                {
                    var orderDetail = await Http.GetFromJsonAsync<OrderDetailVm>($"api/orders/{editModel.OrderId}");

                    if (orderDetail != null)
                    {
                        var cmd = new UpsertOrderCommand();
                        cmd.OrderId = orderDetail.OrderId;
                        cmd.CustomerId = editModel.CustomerId;
                        cmd.EmployeeId = editModel.EmployeeId;
                        cmd.Freight = editModel.Freight;
                        cmd.OrderDate = editModel.OrderDate;
                        cmd.RequiredDate = editModel.RequiredDate;
                        cmd.ShipAddress = editModel.ShipAddress;
                        cmd.ShipCity = editModel.ShipCity;
                        cmd.ShipCountry = editModel.ShipCountry;
                        cmd.ShipName = editModel.ShipName;
                        cmd.ShippedDate = editModel.ShippedDate;
                        cmd.ShipPostalCode = editModel.ShipPostalCode;
                        cmd.ShipRegion = editModel.ShipRegion;
                        cmd.ShipVia = editModel.ShipVia;

                        await Http.PutAsJsonAsync<UpsertOrderCommand>($"api/orders/{cmd.OrderId}", cmd, CancellationToken.None);
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
