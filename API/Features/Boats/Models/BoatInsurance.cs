using System;

namespace API.Features.Boats {

    public class BoatInsurance {

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string Company { get; set; }
        public string ContractNo { get; set; }
        public DateTime ExpireDate { get; set; }

    }

}