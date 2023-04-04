using northwind_blazor.Application.Common.Exceptions;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Application.Common.Services.Identity;

namespace northwind_blazor.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
        {
            private readonly INorthwindDbContext _context;
            private readonly IIdentityService _identityService;
            private readonly ICurrentUser _currentUser;

            public DeleteOrderCommandHandler(INorthwindDbContext context, IIdentityService identityService, ICurrentUser currentUser)
            {
                _context = context;
                _identityService = identityService;
                _currentUser = currentUser;
            }

            public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Orders
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new Common.Exceptions.NotFoundException(nameof(Order), request.Id);
                }


                var hasOrders = _context.OrderDetails.Any(od => od.OrderId == entity.OrderId);
                if (hasOrders)
                {
                    // TODO: Add functional test for this behaviour.
                    throw new DeleteFailureException(nameof(Order), request.Id, "There are existing orders associated with this order.");
                }

                // TODO: Update this logic, this will only work if the Order has no associated territories or orders.Emp

                _context.Orders.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
