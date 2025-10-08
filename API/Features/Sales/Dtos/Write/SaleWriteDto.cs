using System;
using API.Infrastructure.Interfaces;

namespace API.Features.Sales {

    public class SaleWriteDto : IMetadata {

        public Guid InvoiceId { get; set; }
        public Guid ReservationId { get; set; }
        public string Date { get; set; }
        public int InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public int DocumentTypeId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public string Remarks { get; set; }
        public bool IsEmailPending { get; set; }
        public bool IsEmailSent { get; set; }
        public bool IsCancelled { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}