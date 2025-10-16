using API.Infrastructure.Classes;

namespace API.Features.DryDocks {

    public class DryDockListBoatVM {

        public int Id { get; set; }
        public string Description { get; set; }
        public SimpleEntity HullType { get; set; }

    }

}