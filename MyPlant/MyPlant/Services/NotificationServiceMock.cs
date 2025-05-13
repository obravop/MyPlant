using MyPlant.Services.Interfaces;

namespace MyPlant.Services
{
    public class NotificationServiceMock : INotificationService
    {
        public Task NotifyNewUser(string userEmail)
        {
            throw new NotImplementedException();
        }
    }
}
