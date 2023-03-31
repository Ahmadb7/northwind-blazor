using northwind_blazor.WebUI.Shared.TodoLists;

namespace northwind_blazor.Application.TodoLists.Commands
{
    public record UpdateTodoListCommand(UpdateTodoListRequest List) : IRequest;

    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        private readonly INorthwindDbContext _context;

        public UpdateTodoListCommandValidator(INorthwindDbContext context)
        {
            _context = context;

            RuleFor(p => p.List).SetValidator(new UpdateTodoListRequestValidator());

            // Extended validation for server-side.
            RuleFor(p => p.List.Title)
                .MustAsync(BeUniqueTitle)
                    .WithMessage("'Title' must be unique.")
                    .WithErrorCode("UNIQUE_TITLE");
        }

        public async Task<bool> BeUniqueTitle(UpdateTodoListCommand model, string title, CancellationToken cancellationToken)
        {
            return await _context.TodoLists
                .Where(l => l.Id != model.List.Id)
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }

    public class UpdateTodoListCommandHandler
    : AsyncRequestHandler<UpdateTodoListCommand>
    {
        private readonly INorthwindDbContext _context;

        public UpdateTodoListCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists.FindAsync(request.List.Id);

            Guard.Against.NotFound(request.List.Id, entity);

            entity.Title = request.List.Title;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}