using API.Infrastructure.Classes;

namespace API.Features.Customers.Admin {

    public static class CustomerMappingDomainToDto {

        public static CustomerReadDto DomainToDto(Customer customer) {
            return new CustomerReadDto {
                Id = customer.Id,
                Description = customer.Description,
                FullDescription = customer.FullDescription,
                Nationality = new SimpleEntity {
                    Id = customer.Nationality.Id,
                    Description = customer.Nationality.Description,
                },
                TaxOffice = new SimpleEntity {
                    Id = customer.TaxOffice.Id,
                    Description = customer.TaxOffice.Description,
                },
                VatPercent = customer.VatPercent,
                VatPercentId = customer.VatPercentId,
                VatExemptionId = customer.VatExemptionId,
                VatNumber = customer.VatNumber,
                Branch = customer.Branch,
                Profession = customer.Profession,
                Street = customer.Street,
                Number = customer.Number,
                PostalCode = customer.PostalCode,
                City = customer.City,
                PersonInCharge = customer.PersonInCharge,
                Phones = customer.Phones,
                Email = customer.Email,
                Remarks = customer.Remarks,
                IsActive = customer.IsActive,
                PostAt = customer.PostAt,
                PostUser = customer.PostUser,
                PutAt = customer.PutAt,
                PutUser = customer.PutUser
            };
        }

    }

}