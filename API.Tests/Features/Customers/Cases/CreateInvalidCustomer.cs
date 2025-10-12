using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace Customers {

    public class CreateInvalidCustomer : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Nationality_Must_Exist();
            yield return Nationality_Must_Be_Active();
            yield return TaxOffice_Must_Exist();
            yield return TaxOffice_Must_Be_Active();
        }

        private static object[] Nationality_Must_Exist() {
            return [
                new TestCustomer {
                    StatusCode = 457,
                    NationalityId = 999,
                    TaxOfficeId = 1,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128)
                }
            ];
        }

        private static object[] Nationality_Must_Be_Active() {
            return [
                new TestCustomer {
                    StatusCode = 457,
                    NationalityId = 212,
                    TaxOfficeId = 1,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128)
                }
            ];
        }

        private static object[] TaxOffice_Must_Exist() {
            return [
                new TestCustomer {
                    StatusCode = 458,
                    NationalityId = 1,
                    TaxOfficeId = 999,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128)
                }
            ];
        }

        private static object[] TaxOffice_Must_Be_Active() {
            return [
                new TestCustomer {
                    StatusCode = 458,
                    NationalityId = 1,
                    TaxOfficeId = 999,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128)
                }
            ];
        }

    }

}
