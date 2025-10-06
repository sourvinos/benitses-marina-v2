namespace API.Features.DocumentTypes {

    public class DocumentTypeListVM {

        public int Id { get; set; }
        public int DiscriminatorId { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string Batch { get; set; }
        public bool IsActive { get; set; }
        public string Customers { get; set; }

    }

}