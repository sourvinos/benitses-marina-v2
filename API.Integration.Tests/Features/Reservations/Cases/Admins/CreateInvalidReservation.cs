using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class CreateInvalidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Boat_Must_Exist();
            yield return Boat_Must_Be_Active();
        }

        private static object[] Boat_Must_Exist() {
            return new object[] {
                new TestReservation {
                    StatusCode = 452,
                    BoatId = 999,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-01"),
                    IsDocked = true,
                    IsDryDock = false,
                    BoatOwner = new TestReservationBoatOwner {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                     }
                }
            };
        }

        private static object[] Boat_Must_Be_Active() {
            return new object[] {
                new TestReservation {
                    StatusCode = 452,
                    BoatId = 2,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-01"),
                    IsDocked = true,
                    IsDryDock = false,
                    BoatOwner = new TestReservationBoatOwner {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                     }
                }
            };
        }

    }

}
