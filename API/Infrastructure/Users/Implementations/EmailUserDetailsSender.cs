using API.Infrastructure.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorLight;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace API.Infrastructure.Users {

    public class EmailUserDetailsSender(IOptions<EmailUserSettings> emailUserSettings, IOptions<EnvironmentSettings> environmentSettings) : IEmailUserDetailsSender {

        #region variables

        private readonly EmailUserSettings emailUserSettings = emailUserSettings.Value;
        private readonly EnvironmentSettings environmentSettings = environmentSettings.Value;

        #endregion

        public async Task EmailUserDetails(UserExtended user) {
            using var smtp = new SmtpClient();
            smtp.Connect(emailUserSettings.SmtpClient, emailUserSettings.Port);
            smtp.Authenticate(emailUserSettings.Username, emailUserSettings.Password);
            await smtp.SendAsync(await BuildMessage(user));
            smtp.Disconnect(true);
        }

        private async Task<MimeMessage> BuildMessage(UserExtended user) {
            var message = new MimeMessage { Sender = MailboxAddress.Parse(emailUserSettings.Username) };
            message.From.Add(new MailboxAddress(emailUserSettings.From, emailUserSettings.Username));
            message.To.Add(MailboxAddress.Parse(user.Email));
            message.Subject = "✨ Ο νέος λογαριασμός σας είναι έτοιμος";
            message.Body = new BodyBuilder { HtmlBody = await BuildTemplate(user) }.ToMessageBody();
            return message;
        }

        private async Task<string> BuildTemplate(UserExtended user) {
            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();
            return await engine.CompileRenderStringAsync(
                "key",
                LoadNewUserEmailTemplateFromFile(),
                new UserDetailsForEmailVM {
                    Username = user.UserName,
                    Displayname = user.Displayname,
                    Email = user.Email,
                    Url = environmentSettings.BaseUrl,
                    CompanyPhones = environmentSettings.Phones,
                });
        }

        private static string LoadNewUserEmailTemplateFromFile() {
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\UserDetailsForEmail.cshtml";
            StreamReader str = new(FilePath);
            string template = str.ReadToEnd();
            str.Close();
            return template;
        }

    }

}