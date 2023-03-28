using northwind_blazor.Domain.Common;
using northwind_blazor.Domain.Entities;

namespace northwind_blazor.Domain.Events
{
    public class TodoItemCreatedEvent : BaseEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}