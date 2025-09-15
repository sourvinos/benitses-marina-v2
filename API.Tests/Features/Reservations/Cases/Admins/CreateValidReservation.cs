using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class CreateValidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Create_Valid_Reservation();
        }

        private static object[] Create_Valid_Reservation() {
            return [
                new TestReservation {
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new TestReservationBerth { BerthId = 1 },
                        new TestReservationBerth { BerthId = 2 }
                    ],
                    Captain = new TestReservationCaptain {
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
