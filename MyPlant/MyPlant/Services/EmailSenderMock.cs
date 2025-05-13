
namespace MyPlant.Services
{
    public class EmailSenderMock : MyPlant.Services.Interfaces.IEmailSenderService
    {
        public async Task<bool> SendEmail(string userEmail, string subject, string body)
        {
            return true;
        }
    }
}
