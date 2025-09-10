using System;
using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class UpdateValidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Update_Valid_Reservation();
        }

        private static object[] Update_Valid_Reservation() {
            return [
                new TestReservation {
                    ReservationId = Guid.Parse("b486f34c-f8ae-4b14-ba80-79d1f28bac26"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    IsDocked = true,
                    IsDryDock = false,
                    BoatUser = new TestReservationBoatUser {
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                    },
                    PutAt = "2025-08-12 00:00:00"
                }
            ];
        }

    }

}
