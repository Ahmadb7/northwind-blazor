using northwind_blazor.Domain.Common;
using northwind_blazor.Domain.Entities;

namespace northwind_blazor.Domain.Events
{
    public class TodoItemCompletedEvent : BaseEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}