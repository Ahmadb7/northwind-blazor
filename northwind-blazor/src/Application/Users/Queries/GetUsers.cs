using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.WebUI.Shared.AccessControl;

namespace northwind_blazor.Application.Users.Queries
{
    public record GetUsersQuery() : IRequest<UsersVm>;

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UsersVm>
    {
        private readonly IIdentityService _identityService;

        public GetUsersQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<UsersVm> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var result = new UsersVm();

            result.Users = await _identityService.GetUsersAsync(cancellationToken);

            return result;
        }
    }
}