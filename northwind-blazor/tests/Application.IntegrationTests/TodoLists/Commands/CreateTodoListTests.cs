using northwind_blazor.Application.Common.Exceptions;
using northwind_blazor.Application.TodoLists.Commands;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.TodoLists;
using static Testing;

namespace northwind_blazor.Application.SubcutaneousTests.TodoLists.Commands
{
    public class CreateTodoListTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateTodoListCommand(
                new CreateTodoListRequest());

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldRequireUniqueTitle()
        {
            await SendAsync(new CreateTodoListCommand(
                new CreateTodoListRequest { Title = "Shopping" }));

            var command = new CreateTodoListCommand(
                new CreateTodoListRequest { Title = "Shopping" });

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoList()
        {
            var userId = await RunAsDefaultUserAsync();

            var request = new CreateTodoListRequest { Title = "Tasks" };

            var command = new CreateTodoListCommand(request);

            var id = await SendAsync(command);

            var list = await FindAsync<TodoList>(id);

            list.Should().NotBeNull();
            list!.Title.Should().Be(request.Title);
            list.CreatedBy.Should().Be(userId);
            list.CreatedUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
        }
    }
}