using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using API.Infrastructure.Helpers;
using API.Infrastructure.Extensions;

namespace API.Infrastructure.EmailServices {

    public class EmailQueueRepository(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<EmailQueue>(appDbContext, httpContextAccessor, settings, userManager), IEmailQueueRepository {

        #region variables

        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
        private readonly UserManager<UserExtended> userManager = userManager;

        #endregion

        public async Task<EmailQueue> GetFirstNotCompleted() {
            return await context.EmailQueues
                .Where(x => !x.IsSent)
                .OrderBy(x => x.Priority).ThenBy(x => x.PostAt)
                .FirstOrDefaultAsync();
        }

        public async Task<EmailQueue> GetByIdAsync(string entityId) {
            return await context.EmailQueues.FirstOrDefaultAsync(x => x.EntityId.ToString() == entityId);
        }

        public EmailQueue CreateEmailQueue(EmailQueueDto emailQueue) {
            var userId = Identity.GetConnectedUserId(httpContextAccessor);
            return new EmailQueue {
                EntityId = IsNotGuid(emailQueue.EntityId) ? Guid.NewGuid() : emailQueue.EntityId,
                Initiator = emailQueue.Initiator,
                Filenames = emailQueue.Filenames,
                UserFullname = userId != "" ? Identity.GetConnectedUserDetails(userManager, userId).Fullname : "",
                Priority = emailQueue.Priority,
                IsSent = false,
                PostAt = DateHelpers.DateTimeToISOString(DateHelpers.GetLocalDateTime())
            };
        }

        private static bool IsNotGuid(Guid x) {
            return x.ToString().Count(x => x == '0') == 32;
        }

    }

}