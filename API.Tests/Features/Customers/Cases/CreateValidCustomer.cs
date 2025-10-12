using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace Customers {

    public class CreateValidCustomer : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestCustomer {
                    NationalityId = 1,
                    TaxOfficeId = 1,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128)
                }
            ];
        }

    }

}
