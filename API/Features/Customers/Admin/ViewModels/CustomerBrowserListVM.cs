namespace API.Features.Customers.Admin {

    public class CustomerBrowserListVM {

        public int Id { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public decimal VatPercent { get; set; }
        public bool IsActive { get; set; }

    }

}