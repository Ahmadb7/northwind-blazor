using northwind_blazor.Domain.Events;
using northwind_blazor.WebUI.Shared.TodoItems;

namespace northwind_blazor.Application.TodoItems.Commands
{
    public record CreateTodoItemCommand(CreateTodoItemRequest Item) : IRequest<int>;

    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        public CreateTodoItemCommandValidator()
        {
            RuleFor(p => p.Item).SetValidator(new CreateTodoItemRequestValidator());
        }
    }

    public class CreateTodoItemCommandHandler
            : IRequestHandler<CreateTodoItemCommand, int>
    {
        private readonly INorthwindDbContext _context;

        public CreateTodoItemCommandHandler(INorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTodoItemCommand request,
            CancellationToken cancellationToken)
        {
            var entity = new TodoItem
            {
                ListId = request.Item.ListId,
                Title = request.Item.Title,
                Done = false
            };

            entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            _context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ToDoItemId;
        }
    }
}
