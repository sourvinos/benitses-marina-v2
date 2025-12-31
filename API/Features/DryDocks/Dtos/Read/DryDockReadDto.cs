using API.Infrastructure.Classes;

namespace API.Features.DryDocks {

    public class DryDockReadDto {

        public string DryDockId { get; set; }
        public DryDockReadBoatDto Boat { get; set; }
        public SimpleEntity Status { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}