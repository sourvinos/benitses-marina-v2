using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Sales {

    public interface ISaleRepository : IRepository<Sale> {

        IEnumerable<SaleListVM> Get();
        Task<Sale> GetByIdAsync(string reservationId, bool includeTables);
        Sale Update(Guid id, Sale sale);

    }

}