using API.Infrastructure.Interfaces;
using API.Features.Nationalities;
using API.Features.TaxOffices;

namespace API.Features.Customers.Admin {

    public class Customer : IPartyType {

        public int Id { get; set; }
        public int NationalityId { get; set; }
        public int TaxOfficeId { get; set; }
        public Nationality Nationality { get; set; }
        public TaxOffice TaxOffice { get; set; }
        public decimal VatPercent { get; set; }
        public int VatPercentId { get; set; }
        public int VatExemptionId { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string VatNumber { get; set; }
        public int Branch { get; set; }
        public string Profession { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PersonInCharge { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}