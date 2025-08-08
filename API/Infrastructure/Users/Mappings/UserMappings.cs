using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Infrastructure.Users {

    public static class UserMappings {

        public static List<UserListVM> DomainToListVM(List<UserExtended> users) {
            return users.Select(x => new UserListVM {
                Id = x.Id,
                Username = x.UserName,
                Displayname = x.Displayname,
                Email = x.Email,
                IsAdmin = x.IsAdmin,
                IsActive = x.IsActive,
            }).ToList();
        }

        public static UserReadDto DomainToDto(UserExtended user) {
            return new UserReadDto {
                Id = user.Id,
                Username = user.UserName,
                Displayname = user.Displayname,
                IsFirstFieldFocused = user.IsFirstFieldFocused,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                IsActive = user.IsActive,
                PostAt = user.PostAt,
                PostUser = user.PostUser,
                PutAt = user.PutAt,
                PutUser = user.PutUser
            };
        }

        public static UserExtended DtoToDomail(UserNewDto user) {
            return new UserExtended {
                UserName = user.Username.Trim(),
                Displayname = user.Displayname.Trim(),
                IsFirstFieldFocused = user.IsFirstFieldFocused,
                Email = user.Email.Trim(),
                IsAdmin = user.IsAdmin,
                IsActive = user.IsActive,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PostAt = user.PostAt,
                PostUser = user.PostUser,
                PutAt = user.PutAt,
                PutUser = user.PutUser
            };
        }

    }

}