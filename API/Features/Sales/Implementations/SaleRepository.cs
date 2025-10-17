using System.Collections.Generic;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace API.Features.Sales {

    public class SaleRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Sale>(appDbContext, httpContext, testingEnvironment, userManager), ISaleRepository {

        private readonly TestingEnvironment testingEnvironment = testingEnvironment.Value;

        public IEnumerable<SaleListVM> Get() {
            var sales = context.Sales
                .AsNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.DocumentType)
                .Include(x => x.PaymentMethod);
            return SaleMappingReadToList.Read(sales);
        }

        public async Task<Sale> GetByIdAsync(string saleId, bool includeTables) {
            return includeTables
                ? await context.Sales
                    .AsNoTracking()
                    .Include(x => x.Customer)
                    .Include(x => x.DocumentType)
                    .Include(x => x.PaymentMethod)
                    .Include(x => x.Items).ThenInclude(x => x.Item)
                    .Where(x => x.SaleId.ToString() == saleId)
                    .SingleOrDefaultAsync()
               : await context.Sales
                  .AsNoTracking()
                  .Where(x => x.SaleId.ToString() == saleId)
                  .SingleOrDefaultAsync();
        }

        public Sale Update(Guid saleId, Sale sale) {
            using var transaction = context.Database.BeginTransaction();
            UpdateSale(sale);
            UpdateItems(saleId, sale);
            context.SaveChanges();
            DisposeOrCommit(transaction);
            return sale;
        }

        private void UpdateSale(Sale sale) {
            context.Sales.Update(sale);
        }

        private void UpdateItems(Guid saleId, Sale sale) {
            var existingItems = context.SaleItems
                .AsNoTracking()
                .Where(x => x.SaleId == saleId)
                .ToList();
            var itemsToUpdate = sale.Items
                .Where(x => x.Id != 0)
                .ToList();
            var itemsToDelete = existingItems
                .Except(itemsToUpdate, new BerthComparerById())
                .ToList();
            context.SaleItems.RemoveRange(itemsToDelete);
        }

        private class BerthComparerById : IEqualityComparer<SaleItem> {
            public bool Equals(SaleItem x, SaleItem y) {
                return x.Id == y.Id;
            }
            public int GetHashCode(SaleItem x) {
                return x.Id.GetHashCode();
            }
        }

        private void DisposeOrCommit(IDbContextTransaction transaction) {
            if (testingEnvironment.IsTesting) {
                transaction.Dispose();
            } else {
                transaction.Commit();
            }
        }

    }

}