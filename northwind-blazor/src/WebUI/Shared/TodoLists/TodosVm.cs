using northwind_blazor.WebUI.Shared.Common;

namespace northwind_blazor.WebUI.Shared.TodoLists
{
    public class TodosVm
    {
        public List<LookupDto> PriorityLevels { get; set; } = new();

        public List<TodoListDto> Lists { get; set; } = new();
    }
}