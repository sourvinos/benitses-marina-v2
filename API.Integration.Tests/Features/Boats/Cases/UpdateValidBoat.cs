using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Boats {

    public class UpdateValidBoat : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Update_Valid_Boat();
        }

        private static object[] Update_Valid_Boat() {
            return new object[] {
                new TestBoat {
                    Id = 1,
                    BoatUsageId = 1,
                    HullTypeId = 1,
                    Description = "DESCRIPTION",
                    Flag = "",
                    Loa = 12.5M,
                    Beam = 3.5M,
                    Draft = 0.5M,
                    RegistryPort = "",
                    RegistryNo = "",
                    IsAthenian = true,
                    IsFishingBoat = false,
                    IsActive = true,
                    Insurance = new TestBoatInsurance {
                        Company = "AXA",
                        ContractNo  ="3100-16363",
                        ExpireDate = DateHelpers.StringToDate("2050-12-31")
                    },
                    PutAt = "2025-08-12 05:00:18"
                }
            };
        }

    }

}
