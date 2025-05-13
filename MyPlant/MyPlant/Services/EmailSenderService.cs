using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.Diagnostics;

namespace MyPlant.Services
{
    public class EmailSenderService: MyPlant.Services.Interfaces.IEmailSenderService
    {
        public async Task<bool> SendEmail(string userEmail, string subject, string body)
        {
            //TODO: simular tiempo respuesta servidor email
            await Task.Delay(2000);

            Debug.WriteLine($"Email real enviado correctamente.");

            return true;
        }
    }
}
