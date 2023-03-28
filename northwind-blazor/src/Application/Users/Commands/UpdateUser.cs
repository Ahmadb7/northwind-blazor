using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.WebUI.Shared.AccessControl;

namespace northwind_blazor.Application.Users.Commands
{
    public record UpdateUserCommand(UserDto User) : IRequest;

    public class UpdateUserCommandHandler : AsyncRequestHandler<UpdateUserCommand>
    {
        private readonly IIdentityService _identityService;

        public UpdateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _identityService.UpdateUserAsync(request.User);
        }
    }
}