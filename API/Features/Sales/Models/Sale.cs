using System;
using API.Features.Customers.Admin;
using API.Features.DocumentTypes;
using API.Features.PaymentMethods;
using API.Infrastructure.Interfaces;

namespace API.Features.Sales {

    public class Sale : IMetadata {

        public Guid InvoiceId { get; set; }
        public Guid ReservationId { get; set; }
        public DateTime Date { get; set; }
        public int InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public int DocumentTypeId { get; set; }
        public int PaymentMethodId { get; set; }
        public Customer Customer { get; set; }
        public DocumentType DocumentType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
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