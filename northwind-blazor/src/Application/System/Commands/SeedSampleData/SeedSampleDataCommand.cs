using northwind_blazor.Application.Common.Services.Identity;
using northwind_blazor.Persistence;

namespace northwind_blazor.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly INorthwindDbContext _context;
        private readonly IIdentityService _userManager;

        public SeedSampleDataCommandHandler(INorthwindDbContext context, IIdentityService userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context, _userManager);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
