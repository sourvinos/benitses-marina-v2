using System.Collections.Generic;
using API.Infrastructure.Interfaces;

namespace API.Features.Sales {

    public interface ISaleRepository : IRepository<Sale> {

        IEnumerable<SaleListVM> Get();

    }

}