using System.Collections;
using System.Collections.Generic;

namespace Boats {

    public class CreateValidBoat : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Create_Valid_Boat_With_Fishing_Licence_Date_Null();
            yield return Create_Valid_Boat_With_Insurance_Date_Null();
        }

        private static object[] Create_Valid_Boat_With_Fishing_Licence_Date_Null() {
            return [
                new TestBoat {
                    BoatUsageId = 1,
                    HullTypeId = 1,
                    Description = "DESCRIPTION",
                    Flag = "FLAG",
                    Loa = 12.5M,
                    Beam = 3.5M,
                    Draft = 0.5M,
                    RegistryPort = "REGISTRY PORT",
                    RegistryNo = "REGISTRY NO",
                    IsAthenian = true,
                    IsFishingBoat = false,
                    IsActive = true,
                    FishingLicence = new TestBoatFishingLicence {
                        IssuingAuthority = "CORFU",
                        LicenceNo = "123/7456",
                        ExpireDate = null
                    },
                    Insurance = new TestBoatInsurance {
                        Company = "AXA",
                        ContractNo = "3100-16363",
                        ExpireDate = "2025-12-31"
                    }
                }
            ];
        }

        private static object[] Create_Valid_Boat_With_Insurance_Date_Null() {
            return [
                new TestBoat {
                    BoatUsageId = 1,
                    HullTypeId = 1,
                    Description = "DESCRIPTION",
                    Flag = "FLAG",
                    Loa = 12.5M,
                    Beam = 3.5M,
                    Draft = 0.5M,
                    RegistryPort = "REGISTRY PORT",
                    RegistryNo = "REGISTRY NO",
                    IsAthenian = true,
                    IsFishingBoat = false,
                    IsActive = true,
                    FishingLicence = new TestBoatFishingLicence {
                        IssuingAuthority = "CORFU",
                        LicenceNo = "123/7456",
                        ExpireDate = "2025-12-31"
                    },
                    Insurance = new TestBoatInsurance {
                        Company = "AXA",
                        ContractNo = "3100-16363",
                        ExpireDate = null
                    }
                }
            ];
        }

    }

}
