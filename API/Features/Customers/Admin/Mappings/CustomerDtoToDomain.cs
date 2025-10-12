namespace API.Features.Customers.Admin {

    public static class CustomerMappingDtoToDomain {

        public static Customer DtoToDomain(CustomerWriteDto customer) {
            return new Customer {
                Description = customer.Description,
                FullDescription = customer.FullDescription ?? "",
                NationalityId = customer.NationalityId,
                TaxOfficeId = customer.TaxOfficeId,
                VatPercent = customer.VatPercent,
                VatPercentId = customer.VatPercentId,
                VatExemptionId = customer.VatExemptionId,
                VatNumber = customer.VatNumber ?? "",
                Branch = customer.Branch,
                Profession = customer.Profession ?? "",
                Street = customer.Street ?? "",
                Number = customer.Number ?? "",
                PostalCode = customer.PostalCode ?? "",
                City = customer.City ?? "",
                PersonInCharge = customer.PersonInCharge ?? "",
                Phones = customer.Phones ?? "",
                Email = customer.Email ?? "",
                Remarks = customer.Remarks ?? "",
                IsActive = customer.IsActive,
                PostAt = customer.PostAt,
                PostUser = customer.PostUser,
                PutAt = customer.PutAt,
                PutUser = customer.PutUser
            };
        }

    }

}