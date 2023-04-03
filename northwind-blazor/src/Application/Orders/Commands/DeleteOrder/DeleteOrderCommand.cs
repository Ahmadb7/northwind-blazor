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

                if (entity.UserId == _currentUser.UserId)
                {
                    throw new BadRequestException("Orders cannot delete their own account.");
                }

                if (entity.UserId != null)
                {
                    await _identityService.DeleteUserAsync(entity.UserId);
                }

                // TODO: Update this logic, this will only work if the Order has no associated territories or orders.Emp

                _context.Orders.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
