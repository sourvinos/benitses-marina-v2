using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Boats.Insurances {

    [Route("api/[controller]")]
    public class ExpiredInsurancesController(IExpiredInsuranceRepository repo) : ControllerBase {

        #region variables

        private readonly IExpiredInsuranceRepository repo = repo;

        #endregion

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<ExpiredInsuranceVM> Get() {
            return repo.GetExpiredInsurances();
        }

    }

}