using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;
using MyPlant.Services.Interfaces;

namespace MyPlant.Services
{
    public class NotificationService : INotificationService
    {
        private readonly MyPlant.Services.Interfaces.IEmailSenderService _emailSender;

        public NotificationService(MyPlant.Services.Interfaces.IEmailSenderService emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task NotifyNewUser(string userEmail)
        {
            var subject = "Welcome!";
            var body = "Thanks for signing up!";
            var result = await _emailSender.SendEmail(userEmail, subject, body);
        }
    }
}
