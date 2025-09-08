using System;

namespace Reservations {

    public class TestReservation {

        public int StatusCode { get; set; }

        public int Id { get; set; }
        public Guid? ReservationId { get; set; }
        public int BoatId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }
        public string PutAt { get; set; }

        public TestReservationBoatUser BoatUser { get; set; }

    }

}