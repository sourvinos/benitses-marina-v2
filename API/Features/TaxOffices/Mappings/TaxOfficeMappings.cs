using System.Collections.Generic;
using System.Linq;

namespace API.Features.TaxOffices {

    public static class TaxOfficeMappings {

        public static IEnumerable<TaxOfficeListVM> DomainToListVM(IQueryable<TaxOffice> taxOffices) {
            return [.. taxOffices.Select(x => new TaxOfficeListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<TaxOfficeBrowserListVM> DomainToBrowserListVM(IQueryable<TaxOffice> taxOffices) {
            return [.. taxOffices.Select(x => new TaxOfficeBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static TaxOfficeReadDto DomainToDto(TaxOffice taxOffice) {
            return new TaxOfficeReadDto {
                Id = taxOffice.Id,
                Description = taxOffice.Description,
                IsActive = taxOffice.IsActive,
                PostAt = taxOffice.PostAt,
                PostUser = taxOffice.PostUser,
                PutAt = taxOffice.PutAt,
                PutUser = taxOffice.PutUser
            };
        }

        public static TaxOffice DtoToDomail(TaxOfficeWriteDto taxOffice) {
            return new TaxOffice {
                Id = taxOffice.Id,
                Description = taxOffice.Description.Trim(),
                IsActive = taxOffice.IsActive,
                PostAt = taxOffice.PostAt,
                PostUser = taxOffice.PostUser,
                PutAt = taxOffice.PutAt,
                PutUser = taxOffice.PutUser
            };
        }

    }

}