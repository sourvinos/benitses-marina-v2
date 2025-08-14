using System;
using API.Infrastructure.Classes;
using API.Infrastructure.Interfaces;

namespace API.Features.Reservations {

    public class ReservationReadDto : IMetadata {

        public Guid ReservationId { get; set; }
        public ReservationBoatReadDto Boat { get; set; }
        public SimpleEntity Owner { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}