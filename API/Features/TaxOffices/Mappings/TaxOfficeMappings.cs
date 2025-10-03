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

        public static TaxOfficeReadDto DomainToDto(TaxOffice hullType) {
            return new TaxOfficeReadDto {
                Id = hullType.Id,
                Description = hullType.Description,
                IsActive = hullType.IsActive,
                PostAt = hullType.PostAt,
                PostUser = hullType.PostUser,
                PutAt = hullType.PutAt,
                PutUser = hullType.PutUser
            };
        }

        public static TaxOffice DtoToDomail(TaxOfficeWriteDto hullType) {
            return new TaxOffice {
                Id = hullType.Id,
                Description = hullType.Description.Trim(),
                IsActive = hullType.IsActive,
                PostAt = hullType.PostAt,
                PostUser = hullType.PostUser,
                PutAt = hullType.PutAt,
                PutUser = hullType.PutUser
            };
        }

    }

}