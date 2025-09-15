using System;
using System.Collections.Generic;
using API.Features.Boats;
using API.Infrastructure.Interfaces;

namespace API.Features.Reservations {

    public class Reservation : IMetadata {

        public Guid ReservationId { get; set; }
        public int BoatId { get; set; }
        public Boat Boat { get; set; }
        public ReservationCaptain Captain { get; set; }
        public List<ReservationBerth> Berths { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Days { get; set; }
        public bool IsPassingBy { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}