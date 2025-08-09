namespace API.Features.Boats {

    public class BoatBrowserVM {

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Loa { get; set; }
        public decimal Beam { get; set; }
        public decimal Draft { get; set; }
        public string RegistryPort { get; set; }
        public string RegistryNo { get; set; }
        public bool IsActive { get; set; }

    }

}