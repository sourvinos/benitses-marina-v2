using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Boats {

    public class CreateValidBoat : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Create_Valid_Boat();
        }

        private static object[] Create_Valid_Boat() {
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
                    Insurance = new TestBoatInsurance {
                        Company = "AXA",
                        ContractNo  ="3100-16363",
                        ExpireDate = DateHelpers.StringToDate("2050-12-31")
                    }
                }
            ];
        }
    }

}
