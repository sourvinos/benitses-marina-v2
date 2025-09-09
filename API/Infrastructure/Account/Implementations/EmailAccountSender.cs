using API.Infrastructure.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorLight;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace API.Infrastructure.Account {

    public class EmailAccountSender(IOptions<EmailUserSettings> emailUserSettings, IOptions<EnvironmentSettings> environmentSettings) : IEmailAccountSender {

        #region variables

        private readonly EnvironmentSettings environmentSettings = environmentSettings.Value;
        private readonly EmailUserSettings emailUserSettings = emailUserSettings.Value;

        #endregion

        public async Task EmailForgotPassword(string username, string displayname, string email, string returnUrl) {
            using var smtp = new SmtpClient();
            smtp.Connect(emailUserSettings.SmtpClient, emailUserSettings.Port);
            smtp.Authenticate(emailUserSettings.Username, emailUserSettings.Password);
            await smtp.SendAsync(await BuildMessage(username, displayname, email, returnUrl));
            smtp.Disconnect(true);
        }

        private async Task<MimeMessage> BuildMessage(string username, string displayname, string email, string returnUrl) {
            var message = new MimeMessage { Sender = MailboxAddress.Parse(emailUserSettings.Username) };
            message.From.Add(new MailboxAddress(emailUserSettings.From, emailUserSettings.Username));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = "✨ Αίτηση για αλλαγή κωδικού";
            message.Body = new BodyBuilder { HtmlBody = await BuildForgotPasswordTemplate(username, displayname, email, returnUrl) }.ToMessageBody();
            return message;
        }

        private async Task<string> BuildForgotPasswordTemplate(string username, string displayname, string email, string returnUrl) {
            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();
            return await engine.CompileRenderStringAsync(
                "key",
                LoadForgotPasswordTemplateFromFile(),
                new ForgotPasswordResponseVM {
                    Username = username,
                    Displayname = displayname,
                    Email = email,
                    ReturnUrl = returnUrl,
                    CompanyPhones = environmentSettings.Phones,
                });
        }

        private static string LoadForgotPasswordTemplateFromFile() {
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\ResetPassword.cshtml";
            StreamReader str = new(FilePath);
            string template = str.ReadToEnd();
            str.Close();
            return template;
        }

    }

}