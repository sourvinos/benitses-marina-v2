using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace Customers {

    public class UpdateInvalidCustomer : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Nationality_Must_Exist();
            yield return TaxOffice_Must_Exist();
            yield return Customer_Must_Not_Be_Already_Updated();
        }

        private static object[] Nationality_Must_Exist() {
            return [
                new TestCustomer {
                    StatusCode = 457,
                    Id = 1,
                    NationalityId = 999,
                    TaxOfficeId = 1,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-02-07 09:19:25"
                }
            ];
        }

        private static object[] TaxOffice_Must_Exist() {
            return [
                new TestCustomer {
                    StatusCode = 458,
                    Id = 1,
                    NationalityId = 1,
                    TaxOfficeId = 999,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-02-07 09:19:25"
                }
            ];
        }

        private static object[] Customer_Must_Not_Be_Already_Updated() {
            return [
                new TestCustomer {
                    StatusCode = 415,
                    Id = 1,
                    NationalityId = 1,
                    TaxOfficeId = 1,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2023-09-07 09:55:22"
                }
            ];
        }

    }

}
