namespace API.Features.DocumentTypes {

    public class DocumentTypeBrowserListVM {

        public int Id { get; set; }
        public int DiscriminatorId { get; set; }
        public string AbbreviationEn { get; set; }
        public string Description { get; set; }
        public string Batch { get; set; }
        public bool IsActive { get; set; }

    }

}