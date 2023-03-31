using MediatR;

namespace northwind_blazor.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public string Id { get; set; }
    }
}
