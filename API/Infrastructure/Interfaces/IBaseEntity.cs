namespace API.Infrastructure.Interfaces {

    public interface IBaseEntity {

        int Id { get; set; }
        string Description { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}