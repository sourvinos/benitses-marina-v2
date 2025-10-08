using System.Collections.Generic;
using System.Linq;

namespace API.Features.PaymentMethods {

    public static class PaymentMethodMappings {

        public static IEnumerable<PaymentMethodListVM> DomainToListVM(IQueryable<PaymentMethod> paymentMethod) {
            return [.. paymentMethod.Select(x => new PaymentMethodListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<PaymentMethodBrowserListVM> DomainToBrowserListVM(IQueryable<PaymentMethod> paymentMethod) {
            return [.. paymentMethod.Select(x => new PaymentMethodBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static PaymentMethodReadDto DomainToDto(PaymentMethod paymentMethod) {
            return new PaymentMethodReadDto {
                Id = paymentMethod.Id,
                Description = paymentMethod.Description,
                Batch = paymentMethod.Batch,
                MyDataId = paymentMethod.MyDataId,
                IsCredit = paymentMethod.IsCredit,
                IsActive = paymentMethod.IsActive,
                PostAt = paymentMethod.PostAt,
                PostUser = paymentMethod.PostUser,
                PutAt = paymentMethod.PutAt,
                PutUser = paymentMethod.PutUser
            };
        }

        public static PaymentMethod DtoToDomail(PaymentMethodWriteDto paymentMethod) {
            return new PaymentMethod {
                Id = paymentMethod.Id,
                Description = paymentMethod.Description.Trim(),
                Batch = paymentMethod.Batch.Trim(),
                MyDataId = paymentMethod.MyDataId,
                IsCredit = paymentMethod.IsCredit,
                IsActive = paymentMethod.IsActive,
                PostAt = paymentMethod.PostAt,
                PostUser = paymentMethod.PostUser,
                PutAt = paymentMethod.PutAt,
                PutUser = paymentMethod.PutUser
            };
        }

    }

}