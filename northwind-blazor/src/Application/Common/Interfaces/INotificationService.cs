using northwind_blazor.Application.Notifications.Models;
using System.Threading.Tasks;

namespace northwind_blazor.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(MessageDto message);
    }
}
