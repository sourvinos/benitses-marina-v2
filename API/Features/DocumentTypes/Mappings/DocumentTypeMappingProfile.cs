using System.Collections.Generic;
using System.Linq;

namespace API.Features.DocumentTypes {

    public class DocumentTypeMappings {

        public static IEnumerable<DocumentTypeListVM> DomainToListVM(IQueryable<DocumentType> documentTypes) {
            return [.. documentTypes.Select(x => new DocumentTypeListVM {
                Id = x.Id,
                DiscriminatorId = x.DiscriminatorId,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<DocumentTypeBrowserListVM> DomainToBrowserListVM(IQueryable<DocumentType> documentTypes) {
            return [.. documentTypes.Select(x => new DocumentTypeBrowserListVM {
                Id = x.Id,
                DiscriminatorId = x.DiscriminatorId,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static DocumentTypeReadDto DomainToDto(DocumentType documentType) {
            return new DocumentTypeReadDto {
                Id = documentType.Id,
                DiscriminatorId = documentType.DiscriminatorId,
                Description = documentType.Description,
                IsActive = documentType.IsActive,
                PostAt = documentType.PostAt,
                PostUser = documentType.PostUser,
                PutAt = documentType.PutAt,
                PutUser = documentType.PutUser
            };
        }

        public static DocumentType DtoToDomail(DocumentTypeWriteDto documentType) {
            return new DocumentType {
                Id = documentType.Id,
                DiscriminatorId = documentType.DiscriminatorId,
                Abbreviation = documentType.Abbreviation.Trim(),
                AbbreviationEn = documentType.AbbreviationEn.Trim(),
                AbbreviationDataUp = documentType.AbbreviationDataUp.Trim(),
                Description = documentType.Description.Trim(),
                Batch = documentType.Batch,
                Customers = documentType.Customers,
                Suppliers = documentType.Suppliers,
                IsStatistic = documentType.IsStatistic,
                IsActive = documentType.IsActive,
                PostAt = documentType.PostAt,
                PostUser = documentType.PostUser,
                PutAt = documentType.PutAt,
                PutUser = documentType.PutUser
            };
        }

    }

}
