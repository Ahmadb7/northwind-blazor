﻿using northwind_blazor.Domain.Common;

namespace northwind_blazor.Domain.Entities
{
    public class TodoList : BaseAuditableEntity
    {
        public int ToDoListId { get; set; } 

        public string Title { get; set; } = string.Empty;

        public string Colour { get; set; } = string.Empty;

        public ICollection<TodoItem> Items { get; set; }
            = new List<TodoItem>();
    }
}
