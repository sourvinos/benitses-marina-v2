using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using API.Features.Reservations;
using API.Infrastructure.Account;
using API.Infrastructure.Helpers;
using API.Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace API.Infrastructure.EmailServices {

    public class EmailQueueService(IEmailAccountSender emailAccountSender, IEmailQueueRepository emailQueueRepo, IEmailUserDetailsSender emailUserDetailsSender, IOptions<EnvironmentSettings> environmentSettings, IReservationEmailSender reservationEmailSender, IReservationRepository reservationRepo, UserManager<UserExtended> userManager) : BackgroundService {

        #region variables

        private readonly EnvironmentSettings environmentSettings = environmentSettings.Value;
        private readonly IEmailAccountSender emailAccountSender = emailAccountSender;
        private readonly IEmailQueueRepository emailQueueRepo = emailQueueRepo;
        private readonly IEmailUserDetailsSender emailUserDetailsSender = emailUserDetailsSender;
        private readonly IReservationEmailSender reservationEmailSender = reservationEmailSender;
        private readonly UserManager<UserExtended> userManager = userManager;

        #endregion

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {
                await Task.Delay(TimeSpan.FromSeconds(value: environmentSettings.EmailSecondsDelay), stoppingToken);
                var x = await emailQueueRepo.GetFirstNotCompleted();
                if (x != null) {
                    if (x.Initiator == "ResetPassword") { SendResetPassword(x); }
                    if (x.Initiator == "UserDetails") { await SendUserDetailsAsync(x); }
                    if (x.Initiator == "Reservation") { await SendReservationAsync(x); }
                }
            }
        }

        private async void SendResetPassword(EmailQueue emailQueue) {
            var x = userManager.Users.Where(x => x.Id == emailQueue.EntityId.ToString()).FirstOrDefaultAsync().Result;
            if (x != null) {
                var response = emailAccountSender.EmailForgotPassword(x.UserName, x.Displayname, x.Email, environmentSettings.BaseUrl + "/#/resetPassword?email=" + x.Email + "&token=" + WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(await userManager.GeneratePasswordResetTokenAsync(x))));
                if (response.Exception == null) {
                    emailQueue.IsSent = true;
                    emailQueueRepo.Update(emailQueue);
                }
            }
        }

        private async Task SendUserDetailsAsync(EmailQueue emailQueue) {
            var x = await userManager.Users.Where(x => x.Id == emailQueue.EntityId.ToString()).FirstOrDefaultAsync();
            if (x != null) {
                var response = emailUserDetailsSender.EmailUserDetails(x);
                if (response.Exception == null) {
                    emailQueue.IsSent = true;
                    emailQueueRepo.Update(emailQueue);
                }
            }
        }

        private async Task SendReservationAsync(EmailQueue emailQueue) {
            var reservation = await reservationRepo.GetByIdForEmailAsync(emailQueue.EntityId.ToString());
            if (reservation != null) {
                if (reservationEmailSender.SendReservationToEmail(emailQueue, reservation).Exception == null) {
                    emailQueue.IsSent = true;
                    emailQueueRepo.Update(emailQueue);
                }
            }
        }

    }

}