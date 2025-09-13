using System;
using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class UpdateInvalidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Berth_First_Must_Exist();
            yield return Berth_Middle_Must_Exist();
            yield return Berth_Last_Must_Exist();
            yield return Boat_Must_Exist();
            yield return Reservation_Must_Not_Be_Already_Updated();
            yield return Incorrect_Days();
        }

        private static object[] Berth_First_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 454,
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new() { Id = 6, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 99 },
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

        private static object[] Berth_Middle_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 454,
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new() { Id = 6, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 1 },
                        new() { Id = 7, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 99 },
                        new() { Id = 8, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 3 },
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

        private static object[] Berth_Last_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 454,
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new() { Id = 6, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 1 },
                        new() { Id = 7, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 2 },
                        new() { Id = 8, ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"), BerthId = 99 },
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

        private static object[] Boat_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 452,
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 999,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
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

        private static object[] Reservation_Must_Not_Be_Already_Updated() {
            return [
                new TestReservation {
                    StatusCode = 415,
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
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
                    PutAt = "2025-08-13 05:20:08"
                }
            ];
        }

        private static object[] Incorrect_Days() {
            return [
                new TestReservation {
                    StatusCode = 453,
                    ReservationId = Guid.Parse("91430e54-c26b-44aa-956b-ed4477c4013a"),
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 3,
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
                     PutAt = "2025-08-12 00:00:00"
                }
            ];
        }

    }

}
