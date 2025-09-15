using System.Collections;
using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace Reservations {

    public class CreateInvalidReservation : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Berth_First_Must_Exist();
            yield return Berth_Middle_Must_Exist();
            yield return Berth_Last_Must_Exist();
            yield return Boat_Must_Exist();
            yield return Boat_Must_Be_Active();
            yield return Incorrect_Days();
        }

        private static object[] Berth_First_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 454,
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new TestReservationBerth { BerthId = 99 },
                        new TestReservationBerth { BerthId = 1 }
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

        private static object[] Berth_Middle_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 454,
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new TestReservationBerth { BerthId = 1 },
                        new TestReservationBerth { BerthId = 99 },
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

        private static object[] Berth_Last_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 454,
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-10"),
                    Days = 9,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
                    Berths = [
                        new TestReservationBerth { BerthId = 1 },
                        new TestReservationBerth { BerthId = 2 },
                        new TestReservationBerth { BerthId = 99 }
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

        private static object[] Boat_Must_Exist() {
            return [
                new TestReservation {
                    StatusCode = 452,
                    BoatId = 999,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 1,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
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

        private static object[] Boat_Must_Be_Active() {
            return [
                new TestReservation {
                    StatusCode = 452,
                    BoatId = 3,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 1,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
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

        private static object[] Incorrect_Days() {
            return [
                new TestReservation {
                    StatusCode = 453,
                    BoatId = 1,
                    FromDate = DateHelpers.StringToDate("2025-01-01"),
                    ToDate = DateHelpers.StringToDate("2025-01-02"),
                    Days = 3,
                    IsPassingBy = true,
                    IsDocked = true,
                    IsDryDock = false,
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
