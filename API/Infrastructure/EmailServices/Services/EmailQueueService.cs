using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using API.Infrastructure.Account;
using API.Infrastructure.Helpers;
using API.Infrastructure.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace API.Infrastructure.EmailServices {

    public class EmailQueueService(IEmailAccountSender emailAccountSender, IEmailQueueRepository queueRepo, IEmailUserDetailsSender emailUserDetailsSender, IOptions<EnvironmentSettings> environmentSettings, UserManager<UserExtended> userManager) : BackgroundService {

        #region variables

        private readonly EnvironmentSettings environmentSettings = environmentSettings.Value;
        private readonly IEmailAccountSender emailAccountSender = emailAccountSender;
        private readonly IEmailQueueRepository emailQueueRepo = queueRepo;
        private readonly IEmailUserDetailsSender emailUserSender = emailUserDetailsSender;
        private readonly UserManager<UserExtended> userManager = userManager;

        #endregion

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {
                await Task.Delay(TimeSpan.FromSeconds(value: environmentSettings.EmailSecondsDelay), stoppingToken);
                var x = await emailQueueRepo.GetFirstNotCompleted();
                if (x != null) {
                    if (x.Initiator == "ResetPassword") { SendResetPassword(x); }
                    if (x.Initiator == "UserDetails") { await SendUserDetailsAsync(x); }
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
                var response = emailUserSender.EmailUserDetails(x);
                if (response.Exception == null) {
                    emailQueue.IsSent = true;
                    emailQueueRepo.Update(emailQueue);
                }
            }
        }

    }

}