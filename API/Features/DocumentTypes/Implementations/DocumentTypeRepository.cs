using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.DocumentTypes {

    public class DocumentTypeRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<DocumentType>(appDbContext, httpContext, testingEnvironment, userManager), IDocumentTypeRepository {

        public IEnumerable<DocumentTypeListVM> Get() {
            var documentTypes = context.DocumentTypes
                .AsNoTracking()
                .OrderBy(x => x.Description).ThenBy(x => x.Batch);
            return DocumentTypeMappings.DomainToListVM(documentTypes);
        }

        public IEnumerable<DocumentTypeBrowserListVM> GetForBrowser() {
            var documentTypes = context.DocumentTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return DocumentTypeMappings.DomainToBrowserListVM(documentTypes);
        }

        public async Task<DocumentType> GetByIdAsync(int id) {
            return await context.DocumentTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public static IEnumerable<DocumentTypeBrowserListVM> DomainToBrowserListVM(IQueryable<DocumentType> documentTypes) {
            return [.. documentTypes.Select(x => new DocumentTypeBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static DocumentTypeReadDto DomainToDto(DocumentType documentType) {
            return new DocumentTypeReadDto {
                Id = documentType.Id,
                Description = documentType.Description,
                IsActive = documentType.IsActive,
                PostAt = documentType.PostAt,
                PostUser = documentType.PostUser,
                PutAt = documentType.PutAt,
                PutUser = documentType.PutUser
            };
        }

    }

}