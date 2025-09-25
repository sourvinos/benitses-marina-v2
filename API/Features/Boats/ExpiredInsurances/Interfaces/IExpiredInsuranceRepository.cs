using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Features.Boats.Insurances {

    public interface IExpiredInsuranceRepository {

        Task<IEnumerable<ExpiredInsuranceVM>> GetExpiredInsurances();

    }

}