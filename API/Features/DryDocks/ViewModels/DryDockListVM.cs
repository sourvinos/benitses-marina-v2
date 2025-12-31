using API.Infrastructure.Classes;

namespace API.Features.DryDocks {

    public class DryDockListVM {

        public string DryDockId { get; set; }
        public DryDockListBoatVM Boat { get; set; }
        public SimpleEntity Status { get; set; }

    }

}