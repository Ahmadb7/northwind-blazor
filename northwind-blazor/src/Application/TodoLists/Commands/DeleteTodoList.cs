namespace northwind_blazor.Application.TodoLists.Commands
{
    public record DeleteTodoListCommand(int Id) : IRequest;

    public class DeleteTodoListCommandHandler
        : AsyncRequestHandler<DeleteTodoListCommand>
    {
        private readonly INorthwindDbContext _context;

        public DeleteTodoListCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(DeleteTodoListCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.TodoLists
                .Where(l => l.ToDoListId == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            _context.TodoLists.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
