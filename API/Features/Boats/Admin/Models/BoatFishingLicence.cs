using System;

namespace API.Features.Boats.Admin {

    public class BoatFishingLicence {

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string IssuingAuthority { get; set; }
        public string LicenceNo { get; set; }
        public DateTime? ExpireDate { get; set; }
 
    }

}