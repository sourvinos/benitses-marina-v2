using System.Collections.Generic;

namespace API.Features.Boats.Insurances {

    public interface IExpiredInsuranceRepository {

        IEnumerable<ExpiredInsuranceVM> GetExpiredInsurances();

    }

}