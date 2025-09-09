using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using API.Infrastructure.Interfaces;
using API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace API.Infrastructure.Users {

    public class UserRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, IOptions<TestingEnvironment> testingSettings, UserManager<UserExtended> userManager) : IUserRepository {

        #region variables

        private readonly AppDbContext context = context;
        private readonly IHttpContextAccessor httpContextAccessor = httpContextAccessor;
        private readonly TestingEnvironment testingSettings = testingSettings.Value;
        private readonly UserManager<UserExtended> userManager = userManager;

        #endregion

        public async Task<IEnumerable<UserListVM>> GetAsync() {
            var users = await userManager.Users
                .AsNoTracking()
                .OrderBy(o => o.UserName)
                .ToListAsync();
            return UserMappings.DomainToListVM(users);
        }

        public async Task<UserExtended> GetByIdAsync(string id) {
            return await userManager.Users
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserExtended> GetByEmailAsync(string email) {
            return await userManager.Users
                .SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IdentityResult> CreateAsync(UserExtended entity, string password) {
            using var transaction = context.Database.BeginTransaction();
            var result = await userManager.CreateAsync(entity, password);
            if (result.Succeeded) {
                await userManager.AddToRoleAsync(entity, entity.IsAdmin ? "Admin" : "User");
                DisposeOrCommit(transaction);
            }
            return result;
        }

        public async Task<bool> UpdateAdminAsync(UserExtended entity, UserUpdateDto entityToUpdate) {
            if (await UpdateUser(entity, entityToUpdate, "admin")) {
                await UpdateUserRole(entity);
                return true;
            } else {
                return false;
            }
        }

        public async Task<bool> UpdateSimpleUserAsync(UserExtended entity, UserUpdateDto entityToUpdate) {
            if (await UpdateUser(entity, entityToUpdate, "simpleUser")) {
                return true;
            } else {
                return false;
            }
        }

        public IMetadata AttachMetadataToPostDto(IMetadata entity) {
            entity.PostAt = DateHelpers.DateTimeToISOString(DateHelpers.GetLocalDateTime());
            entity.PostUser = Identity.GetConnectedUserDetails(userManager, Identity.GetConnectedUserId(httpContextAccessor)).UserName;
            entity.PutAt = entity.PostAt;
            entity.PutUser = entity.PostUser;
            return entity;
        }

        public string CreateTemporaryPassword() {
            string validChars = "ABCDEabcde01234!@#$%";
            Random random = new();
            char[] chars = new char[20];
            for (int i = 0; i < 20; i++) {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        private async Task<bool> UpdateUser(UserExtended entity, UserUpdateDto entityToUpdate, string role) {
            entity.Displayname = entityToUpdate.Displayname;
            entity.IsFirstFieldFocused = entityToUpdate.IsFirstFieldFocused;
            entity.PostAt = entity.PostAt;
            entity.PostUser = entity.PostUser;
            entity.PutAt = DateHelpers.DateTimeToISOString(DateHelpers.GetLocalDateTime());
            entity.PutUser = Identity.GetConnectedUserDetails(userManager, Identity.GetConnectedUserId(httpContextAccessor)).UserName;
            if (role == "admin") {
                entity.UserName = entityToUpdate.Username;
                entity.Email = entityToUpdate.Email;
                entity.IsAdmin = entityToUpdate.IsAdmin;
                entity.IsActive = entityToUpdate.IsActive;
            }
            var result = await userManager.UpdateAsync(entity);
            return result.Succeeded;
        }

        private async Task UpdateUserRole(UserExtended entity) {
            var roles = await userManager.GetRolesAsync(entity);
            await userManager.RemoveFromRolesAsync(entity, roles);
            await userManager.AddToRoleAsync(entity, entity.IsAdmin ? "admin" : "user");
        }

        private void DisposeOrCommit(IDbContextTransaction transaction) {
            if (testingSettings.IsTesting) {
                transaction.Dispose();
            } else {
                transaction.Commit();
            }
        }

    }

}