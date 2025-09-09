using API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace API.Infrastructure.Users {

    public class UserValidation(IHttpContextAccessor httpContext, UserManager<UserExtended> userManager) : IUserValidation<IUser> {

        #region variables

        private readonly IHttpContextAccessor httpContext = httpContext;
        private readonly UserManager<UserExtended> userManager = userManager;

        #endregion


        public int IsValid(IUser user) {
            return true switch {
                _ => 200,
            };
        }

        public bool IsUserOwner(string userId) {
            var connectedUserId = Identity.GetConnectedUserId(httpContext);
            var connectedUserDetails = Identity.GetConnectedUserDetails(userManager, userId);
            return connectedUserDetails.Id == connectedUserId;
        }

    }

}
