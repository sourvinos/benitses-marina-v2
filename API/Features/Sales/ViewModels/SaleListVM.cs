using System;
using API.Infrastructure.Classes;

namespace API.Features.Sales {

    public class SaleListVM {

        public Guid SaleId { get; set; }
        public string Date { get; set; }
        public SimpleEntity Customer { get; set; }
        public SimpleEntity DocumentType { get; set; }
        public int InvoceNo { get; set; }
        public decimal GrossAmount { get; set; }
        public bool IsEmailPending { get; set; }
        public bool IsEmailSent { get; set; }

    }

}