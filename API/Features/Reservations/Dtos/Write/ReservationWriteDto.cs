using System;
using System.Collections.Generic;
using API.Infrastructure.Interfaces;

namespace API.Features.Reservations {

    public class ReservationWriteDto : IMetadata {

        public Guid ReservationId { get; set; }
        public int BoatId { get; set; }
        public ReservationCaptainWriteDto Captain { get; set; }
        public List<ReservationBerthWriteDto> Berths { get; set; } = [];
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Days { get; set; }
        public bool IsPassingBy { get; set; }
        public bool IsDocked { get; set; }
        public bool IsDryDock { get; set; }
        public bool IsDeleted { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}