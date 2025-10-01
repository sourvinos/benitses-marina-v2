namespace API.Features.Prices {

    public class PriceListBrowserVM {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string NetAmount { get; set; }
        public string VatAmount { get; set; }
        public string GrossAmount { get; set; }
        public bool IsActive { get; set; }

    }

}