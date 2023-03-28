﻿using northwind_blazor.Application.Common.Services.Identity;

namespace northwind_blazor.Application.Roles.Commands
{
    public record DeleteRoleCommand(string RoleId) : IRequest;

    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly IIdentityService _identityService;

        public DeleteRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _identityService.DeleteRoleAsync(request.RoleId);
        }
    }
}