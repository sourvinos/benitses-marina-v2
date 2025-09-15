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
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new() { Id = 6, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 1 },
                        new() { Id = 7, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 2 }
                    ],
                    Captain = new TestReservationCaptain {
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
