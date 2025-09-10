using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class CreateInvalidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Boat_Must_Exist();
            yield return Boat_Must_Be_Active();
            yield return Incorrect_Days();
        }

        private static object[] Boat_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 452,
                    BoatId = 999,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 1,
                    IsDocked = true,
                    IsDryDock = false,
                    BoatUser = new TestReservationBoatUser {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                     }
                }
            ];
        }

        private static object[] Boat_Must_Be_Active() {
            return [
                new TestReservation {
                    StatusCode = 452,
                    BoatId = 3,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 1,
                    IsDocked = true,
                    IsDryDock = false,
                    BoatUser = new TestReservationBoatUser {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                     }
                }
            ];
        }

        private static object[] Incorrect_Days() {
            return [
                new TestReservation {
                    StatusCode = 453,
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 3,
                    IsDocked = true,
                    IsDryDock = false,
                    BoatUser = new TestReservationBoatUser {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                     }
                }
            ];
        }

    }

}
