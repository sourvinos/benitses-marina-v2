using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Boats {

    public class CreateInvalidBoat : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return BoatUsage_Must_Exist();
            yield return BoatUsage_Must_Be_Active();
            yield return HullType_Must_Exist();
            yield return HullType_Must_Be_Active();
        }

        private static object[] BoatUsage_Must_Exist() {
            return [
                new TestBoat {
                    StatusCode = 450,
                    BoatUsageId = 99,
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
                    }
                }
            ];
        }

        private static object[] BoatUsage_Must_Be_Active() {
            return [
                new TestBoat {
                    StatusCode = 450,
                    BoatUsageId = 3,
                    HullTypeId = 1,
                    Description =   "DESCRIPTION",
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
                    }
                }
            ];
        }

        private static object[] HullType_Must_Exist() {
            return [
                new TestBoat {
                    StatusCode = 451,
                    BoatUsageId = 1,
                    HullTypeId = 99,
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
                    }
                }
            ];
        }

        private static object[] HullType_Must_Be_Active() {
            return [
                new TestBoat {
                    StatusCode = 451,
                    BoatUsageId = 1,
                    HullTypeId = 3,
                    Description =   "DESCRIPTION",
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
                    }
                }
            ];
        }

    }

}
