﻿using northwind_blazor.Application.Common.Exceptions;
using northwind_blazor.Application.TodoItems.Commands;
using northwind_blazor.Application.TodoLists.Commands;
using northwind_blazor.Domain.Entities;
using northwind_blazor.WebUI.Shared.TodoItems;
using northwind_blazor.WebUI.Shared.TodoLists;
using static northwind_blazor.Application.SubcutaneousTests.Testing;

namespace northwind_blazor.Application.SubcutaneousTests.TodoItems.Commands
{
    public class CreateTodoItemTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireMinimumFields()
        {
            var command = new CreateTodoItemCommand(
                new CreateTodoItemRequest());

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateTodoListCommand(
                new CreateTodoListRequest
                {
                    Title = "New List"
                }));

            var command = new CreateTodoItemCommand(
                new CreateTodoItemRequest
                {
                    ListId = listId,
                    Title = "Tasks"
                });

            var itemId = await SendAsync(command);

            var item = await FindAsync<TodoItem>(itemId);

            item.Should().NotBeNull();
            item!.ListId.Should().Be(command.Item.ListId);
            item.Title.Should().Be(command.Item.Title);
            item.CreatedBy.Should().Be(userId);
            item.CreatedUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
            item.LastModifiedBy.Should().Be(userId);
            item.LastModifiedUtc.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
        }
    }
}
