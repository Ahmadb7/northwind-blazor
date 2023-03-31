using MediatR;

namespace northwind_blazor.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListVm>
    {
    }
}
