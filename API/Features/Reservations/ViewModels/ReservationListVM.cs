using System;
using System.Collections.Generic;

namespace API.Features.Reservations {

    public class ReservationListVM {

        public Guid ReservationId { get; set; }
        public ReservationListBoatVM Boat { get; set; }
        public List<ReservationListBerthVM> Berths { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }

    }

}