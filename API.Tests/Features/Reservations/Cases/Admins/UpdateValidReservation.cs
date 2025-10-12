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
                    ReservationId = Guid.Parse("08ddf478-3633-41ce-8dd9-d7abb2f9be3c"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-12"),
                    Days = 11,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new() { Id = 6, ReservationId = Guid.Parse("08ddf478-3633-41ce-8dd9-d7abb2f9be3c"), BerthId = 2 },
                        new() { Id = 7, ReservationId = Guid.Parse("08ddf478-3633-41ce-8dd9-d7abb2f9be3c"), BerthId = 1 }
                    ],
                    Captain = new TestReservationCaptain {
                        ReservationId = Guid.Parse("08ddf478-3633-41ce-8dd9-d7abb2f9be3c"),
                        Name = "NAME",
                        Address = "ADDRESS",
                        TaxNo = "TAX NUMBER",
                        TaxOffice = "TAX OFFICE",
                        Phones = "PHONES",
                        Email = "email@server.com"
                    },
                    PutAt = "2025-08-13 05:25:08"
                }
            ];
        }

    }

}
