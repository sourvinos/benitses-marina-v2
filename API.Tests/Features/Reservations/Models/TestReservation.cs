using System;
using System.Collections.Generic;

namespace Reservations {

    public class TestReservation {

        public int StatusCode { get; set; }

        public Guid? ReservationId { get; set; }
        public int BoatId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Days { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }
        public bool IsPassingBy { get; set; }
        public bool IsDeleted { get; set; }
        public string PutAt { get; set; }
        public List<TestReservationBerth> Berths { get; set; }
        public TestReservationCaptain Captain { get; set; }

    }

}