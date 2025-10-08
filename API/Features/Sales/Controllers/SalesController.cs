using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Sales {

    [Route("api/[controller]")]
    public class SalesController(ISaleRepository repo, ISaleValidation validation) : ControllerBase {

        #region variables

        private readonly ISaleRepository repo = repo;
        private readonly ISaleValidation validation = validation;

        #endregion

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<SaleListVM> Get() {
            return repo.Get();
        }

    }

}