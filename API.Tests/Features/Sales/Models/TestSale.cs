using System;
using System.Collections.Generic;
using API.Features.Customers.Admin;
using API.Features.DocumentTypes;
using API.Features.PaymentMethods;
using API.Infrastructure.Interfaces;

namespace API.Features.Sales {

    public class TestSale : IMetadata {

        public int StatusCode { get; set; }

        public Guid SaleId { get; set; }
        public int DiscriminatorId { get; set; }
        public string Date { get; set; }
        public int InvoiceNo { get; set; }
        public int CustomerId { get; set; }
        public int DocumentTypeId { get; set; }
        public int PaymentMethodId { get; set; }
        public Customer Customer { get; set; }
        public DocumentType DocumentType { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public List<TestSaleItem> Items { get; set; }
        public bool IsEmailPending { get; set; }
        public bool IsEmailSent { get; set; }
        public bool IsCancelled { get; set; }
        public string Remarks { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}