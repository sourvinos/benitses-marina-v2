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
            yield return Incorrect_Days();
        }

        private static object[] Boat_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 452,
                    ReservationId = Guid.Parse("b486f34c-f8ae-4b14-ba80-79d1f28bac26"),
                    BoatId = 999,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 10,
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
                     PutAt = "2025-08-13 05:25:08"
                }
            ];
        }

        private static object[] Reservation_Must_Not_Be_Already_Updated() {
            return [
                new TestReservation {
                    StatusCode = 415,
                    ReservationId = Guid.Parse("b486f34c-f8ae-4b14-ba80-79d1f28bac26"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
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
                    PutAt = "2025-08-13 05:25:08"
                }
            ];
        }

        private static object[] Incorrect_Days() {
            return [
                new TestReservation {
                    StatusCode = 453,
                    ReservationId = Guid.Parse("b486f34c-f8ae-4b14-ba80-79d1f28bac26"),
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
                     },
                     PutAt = "2025-08-12 00:00:00"
                }
            ];
        }

    }

}
