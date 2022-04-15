using System.Threading.Tasks;
using FantasySoccerApp.MobileAppService.Services.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FantasySoccerApp.MobileAppService.Services
{
    public class SendGridService : ISendGridService
    {
        public async Task SendResetPasswordEmailAsync(string apiKey, string sendId)
        {
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("test@example.com", "Jerun Trajko"),
                Subject = "Fantasy Soccer App: Reset Password Request",
                PlainTextContent = "and easy to do anywhere, even with C#",
                HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>"
            };
            msg.AddTo(new EmailAddress("test@example.com", "Test User"));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
