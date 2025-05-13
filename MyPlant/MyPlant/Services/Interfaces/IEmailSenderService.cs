namespace MyPlant.Services.Interfaces
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmail(string userEmail, string subject, string body);
    }
}
