using northwind_blazor.Application.Common.Exceptions;
using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Application.Common.Services.Identity;

namespace northwind_blazor.Application.Employees.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
        {
            private readonly INorthwindDbContext _context;
            private readonly IIdentityService _identityService;
            private readonly ICurrentUser _currentUser;

            public DeleteEmployeeCommandHandler(INorthwindDbContext context, IIdentityService identityService, ICurrentUser currentUser)
            {
                _context = context;
                _identityService = identityService;
                _currentUser = currentUser;
            }

            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Employees
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new Common.Exceptions.NotFoundException(nameof(Employee), request.Id);
                }

                if (entity.UserId == _currentUser.UserId)
                {
                    throw new BadRequestException("Employees cannot delete their own account.");
                }

                if (entity.UserId != null)
                {
                    await _identityService.DeleteUserAsync(entity.UserId);
                }

                // TODO: Update this logic, this will only work if the employee has no associated territories or orders.Emp

                _context.Employees.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
