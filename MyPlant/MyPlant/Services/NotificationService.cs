using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;
using MyPlant.Services.Interfaces;

namespace MyPlant.Services
{
    public class NotificationService : INotificationService
    {
        private readonly MyPlant.Services.Interfaces.IEmailSenderService _emailSender;
        private readonly ILogService _logService;

        public NotificationService(MyPlant.Services.Interfaces.IEmailSenderService emailSender, ILogService logService)
        {
            _emailSender = emailSender;
            _logService = logService;
        }

        public async Task NotifyNewUser(string userEmail)
        {
            try
            {
                var subject = "Welcome!";
                var body = "Thanks for signing up!";
                var result = await _emailSender.SendEmail(userEmail, subject, body);
                await _logService.Log("Envío email exitoso");
            }
            catch (Exception)
            {
                await _logService.Log("Ocurrió un error al enviar el email");
                throw;
            }
        }
    }
}
