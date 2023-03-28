using Ardalis.GuardClauses;
using northwind_blazor.Application.TodoLists.Commands;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.TodoLists;
using static Testing;

namespace northwind_blazor.Application.SubcutaneousTests.TodoLists.Commands
{
    public class DeleteTodoListTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand(99);

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand(
                new CreateTodoListRequest
                {
                    Title = "New List"
                }));

            await SendAsync(new DeleteTodoListCommand(listId));

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}