namespace API.Features.Boats {

    public static class BoatMappingDomainToBrowserVM {

        public static BoatBrowserVM DomainToBrowserVM(Boat boat) {
            return new BoatBrowserVM {
                Id = boat.Id,
                Description = boat.Description,
                Loa = boat.Loa,
                Beam = boat.Beam,
                Draft = boat.Draft,
                IsActive = boat.IsActive
            };
        }

   }

}