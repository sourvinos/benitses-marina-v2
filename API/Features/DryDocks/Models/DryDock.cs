using System;
using API.Features.Boats.Admin;
using API.Infrastructure.Interfaces;

namespace API.Features.DryDocks {

    public class DryDock : IMetadata {

        public Guid Id { get; set; }
        public int BoatId { get; set; }
        public int StatusId { get; set; }
        public Boat Boat { get; set; }
        public DryDockStatus Status { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDeleted { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}