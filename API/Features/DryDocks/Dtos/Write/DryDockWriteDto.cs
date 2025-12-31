using System;
using API.Infrastructure.Interfaces;

namespace API.Features.DryDocks {

    public class DryDockWriteDto : IMetadata {

        public Guid DryDockId { get; set; }
        public int BoatId { get; set; }
        public int StatusId { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDeleted { get; set; }
        public string Remarks { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}