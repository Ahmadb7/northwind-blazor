using Ardalis.GuardClauses;
using northwind_blazor.Application.TodoItems.Commands;
using northwind_blazor.Application.TodoLists.Commands;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.TodoItems;
using northwind_blazor.WebUI.Shared.TodoLists;
using static northwind_blazor.Application.SubcutaneousTests.Testing;

namespace northwind_blazor.Application.SubcutaneousTests.TodoItems.Commands
{
    public class DeleteTodoItemTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireValidTodoItemId()
        {
            var command = new DeleteTodoItemCommand(99);

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateTodoListCommand(
                new CreateTodoListRequest
                {
                    Title = "New List"
                }));

            var itemId = await SendAsync(new CreateTodoItemCommand(
                new CreateTodoItemRequest
                {
                    ListId = listId,
                    Title = "Tasks"
                }));

            await SendAsync(new DeleteTodoItemCommand(itemId));

            var item = await FindAsync<TodoItem>(itemId);

            item.Should().BeNull();
        }
    }
}
