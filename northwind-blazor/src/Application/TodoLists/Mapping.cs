using northwind_blazor.WebUI.Shared.TodoLists;

namespace northwind_blazor.Application.TodoLists
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, TodoListDto>();
            CreateMap<TodoItem, TodoItemDto>();
        }
    }
}