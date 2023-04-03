using System.Collections.Generic;

namespace northwind_blazor.Application.Orders.Queries.GetOrdersList
{
    public class OrdersListVm
    {
        public IList<OrderLookupDto> Orders { get; set; }
    }
}
