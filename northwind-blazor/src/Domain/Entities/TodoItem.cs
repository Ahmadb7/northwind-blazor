using northwind_blazor.Domain.Common;
using northwind_blazor.Domain.Enums;

namespace northwind_blazor.Domain.Entities
{
    public class TodoItem : BaseAuditableEntity
    {
        public int ToDoItemId { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }

        public TodoList List { get; set; } = null!;
    }
}
