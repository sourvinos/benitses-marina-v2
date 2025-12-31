using System;
using System.Collections.Generic;

namespace API.Features.Reservations {

    public class ReservationListVM {

        public Guid ReservationId { get; set; }
        public ReservationListBoatVM Boat { get; set; }
        public IEnumerable<ReservationListBerthVM> Berths { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Days { get; set; }
        public bool IsAthenian { get; set; }
        public bool IsFishingBoat { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }
        public bool IsPassingBy { get; set; }
        public bool IsOverdue { get; set; }

    }

}