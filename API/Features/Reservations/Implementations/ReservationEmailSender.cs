using API.Infrastructure.EmailServices;
using API.Infrastructure.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using RazorLight;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace API.Features.Reservations {

    public class ReservationEmailSender(IReservationRepository reservationRepo, IOptions<EmailReservationSettings> emailReservationSettings) : IReservationEmailSender {

        #region variables

        private readonly EmailReservationSettings emailReservationSettings = emailReservationSettings.Value;
        private readonly IReservationRepository reservationRepo = reservationRepo;

        #endregion

        public async Task SendReservationToEmail(EmailQueue emailQueue, Reservation reservation) {
            using var smtp = new SmtpClient();
            smtp.Connect(emailReservationSettings.SmtpClient, emailReservationSettings.Port);
            smtp.Authenticate(emailReservationSettings.Username, emailReservationSettings.Password);
            await smtp.SendAsync(await BuildReservationMessage(emailQueue, reservation.Boat.Description, reservation.Captain.Email));
            smtp.Disconnect(true);
        }

        private async Task<MimeMessage> BuildReservationMessage(EmailQueue model, string boat, string email) {
            var message = new MimeMessage { Sender = MailboxAddress.Parse(emailReservationSettings.Username) };
            message.From.Add(new MailboxAddress(emailReservationSettings.From, emailReservationSettings.Username));
            message.To.AddRange(BuildReceivers(email));
            message.Subject = "⚓ Invoice & lease agreement for vessel '" + boat + "'";
            var builder = new BodyBuilder { HtmlBody = await BuildEmailReservationTemplateAsync(model) };
            var filenames = model.Filenames.Split(",");
            foreach (var filename in filenames) {
                builder.Attachments.Add(Path.Combine("Uploaded Lease Agreements" + Path.DirectorySeparatorChar + model.EntityId.ToString() + " " + filename.Trim()));
            }
            builder.Attachments.Add(Path.Combine("Uploaded Documents" + Path.DirectorySeparatorChar + "Pillar instructions.pdf"));
            builder.Attachments.Add(Path.Combine("Uploaded Documents" + Path.DirectorySeparatorChar + "Wi-Fi and Showers Passkeys.pdf"));
            message.Body = builder.ToMessageBody();
            return message;
        }

        private static InternetAddressList BuildReceivers(string email) {
            InternetAddressList internetAddressList = new();
            var emails = email.Split(",");
            foreach (string address in emails) {
                internetAddressList.Add(MailboxAddress.Parse(EmailHelpers.BeValidEmailAddress(address.Trim()) ? address.Trim() : "postmaster@appbenitsesmarina.com"));
            }
            return internetAddressList;
        }

        private static async Task<string> BuildEmailReservationTemplateAsync(EmailQueue model) {
            RazorLightEngine engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(Assembly.GetEntryAssembly())
                .Build();
            return await engine.CompileRenderStringAsync("key", LoadEmailReservationTemplateFromFile(), new ReservationEmailTemplateVM {
                UserFullname = model.UserFullname,
                Email = "info@benitsesmarina.com",
                CompanyPhones = "+30 26610 72627, +30 6937 133 662",
                Website = "www.benitsesmarina.com"
            });
        }

        private static string LoadEmailReservationTemplateFromFile() {
            string FilePath = Directory.GetCurrentDirectory() + "\\Templates\\EmailReservation.cshtml";
            StreamReader str = new(FilePath);
            string template = str.ReadToEnd();
            str.Close();
            return template;
        }
 
    }

}