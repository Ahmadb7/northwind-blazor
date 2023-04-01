using System.Collections.Generic;

namespace northwind_blazor.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListVm
    {
        public List<CustomerLookupDto> Customers { get; set; }
    }
}
