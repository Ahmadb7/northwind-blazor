using northwind_blazor.Application.Common.Interfaces;
using northwind_blazor.Application.Notifications.Models;

namespace northwind_blazor.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(MessageDto message)
        {
            return Task.CompletedTask;
        }
    }
}
