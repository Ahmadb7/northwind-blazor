using MediatR;

namespace northwind_blazor.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
