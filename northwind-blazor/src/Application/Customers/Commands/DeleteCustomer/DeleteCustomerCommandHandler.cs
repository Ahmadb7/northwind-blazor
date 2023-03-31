using northwind_blazor.Application.Common.Exceptions;

namespace northwind_blazor.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly INorthwindDbContext _context;

        public DeleteCustomerCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Common.Exceptions.NotFoundException(nameof(Customer), request.Id);
            }

            var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing orders associated with this customer.");
            }

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
