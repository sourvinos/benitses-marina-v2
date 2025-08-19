using System;
using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class UpdateInvalidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Boat_Must_Exist();
            yield return Reservation_Must_Not_Be_Already_Updated();
        }

        private static object[] Boat_Must_Exist() {
            return new object[] {
                new TestReservation {
                    StatusCode = 452,
                    ReservationId = Guid.Parse("08ddda11-0ce6-4a22-85bd-d16bd63e2a88"),
                    BoatId = 999,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
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

        private static object[] Reservation_Must_Not_Be_Already_Updated() {
            return new object[] {
                new TestReservation {
                    StatusCode = 415,
                    ReservationId = Guid.Parse("08ddda11-0ce6-4a22-85bd-d16bd63e2a88"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    IsDocked = true,
                    IsDryDock = false,
                    BoatOwner = new TestReservationBoatOwner {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                    },
                    PutAt = "2025-08-13 05:25:08"
                }
            };
        }

    }

}
