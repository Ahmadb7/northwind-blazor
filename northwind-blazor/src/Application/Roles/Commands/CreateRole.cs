using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.WebUI.Shared.AccessControl;

namespace northwind_blazor.Application.Roles.Commands
{
    public record CreateRoleCommand(RoleDto Role) : IRequest;

    public class CreateRoleCommandHandler : AsyncRequestHandler<CreateRoleCommand>
    {
        private readonly IIdentityService _identityService;

        public CreateRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            await _identityService.CreateRoleAsync(request.Role);
        }
    }
}