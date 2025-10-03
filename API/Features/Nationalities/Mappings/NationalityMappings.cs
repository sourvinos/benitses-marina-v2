using System.Collections.Generic;
using System.Linq;

namespace API.Features.Nationalities {

    public static class NationalityMappings {

        public static IEnumerable<NationalityListVM> DomainToListVM(IQueryable<Nationality> nationalities) {
            return [.. nationalities.Select(x => new NationalityListVM {
                Id = x.Id,
                Description = x.Description,
                Code = x.Code,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<NationalityBrowserListVM> DomainToBrowserListVM(IQueryable<Nationality> nationalities) {
            return [.. nationalities.Select(x => new NationalityBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                Code = x.Code,
                IsActive = x.IsActive,
            })];
        }

        public static NationalityReadDto DomainToDto(Nationality nationality) {
            return new NationalityReadDto {
                Id = nationality.Id,
                Description = nationality.Description,
                Code = nationality.Code,
                IsActive = nationality.IsActive,
                PostAt = nationality.PostAt,
                PostUser = nationality.PostUser,
                PutAt = nationality.PutAt,
                PutUser = nationality.PutUser
            };
        }

        public static Nationality DtoToDomail(NationalityWriteDto nationality) {
            return new Nationality {
                Id = nationality.Id,
                Description = nationality.Description.Trim(),
                Code = nationality.Code.Trim(),
                IsActive = nationality.IsActive,
                PostAt = nationality.PostAt,
                PostUser = nationality.PostUser,
                PutAt = nationality.PutAt,
                PutUser = nationality.PutUser
            };
        }

    }

}