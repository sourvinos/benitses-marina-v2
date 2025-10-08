using System.Collections.Generic;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Sales {

    public class SaleRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Sale>(appDbContext, httpContext, testingEnvironment, userManager), ISaleRepository {

        private readonly TestingEnvironment testingEnvironment = testingEnvironment.Value;

        public IEnumerable<SaleListVM> Get() {
            var reservations = context.Sales
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.DocumentType)
                .Include(x => x.PaymentMethod);
            return SaleDomainToListVM.Read(reservations);
        }

    }

}