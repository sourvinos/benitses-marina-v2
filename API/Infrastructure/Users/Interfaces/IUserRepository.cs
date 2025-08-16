using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Infrastructure.Users {

    public interface IUserRepository {

        Task<IEnumerable<UserListVM>> GetAsync();
        Task<UserExtended> GetByIdAsync(string id);
        Task<UserExtended> GetByEmailAsync(string email);
        Task<IdentityResult> CreateAsync(UserExtended entity, string password);
        Task<bool> UpdateAdminAsync(UserExtended entity, UserUpdateDto userToUpdate);
        Task<bool> UpdateSimpleUserAsync(UserExtended entity, UserUpdateDto userToUpdate);
        IMetadata AttachMetadataToPostDto(IMetadata entity);
        string CreateTemporaryPassword();

    }

}