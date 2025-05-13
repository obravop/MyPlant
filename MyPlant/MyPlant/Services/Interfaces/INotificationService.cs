namespace MyPlant.Services.Interfaces
{
    public interface INotificationService
    {
        Task NotifyNewUser(string userEmail);
    }
}