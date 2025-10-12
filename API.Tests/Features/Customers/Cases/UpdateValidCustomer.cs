using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace Customers {

    public class UpdateValidCustomer : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestCustomer {
                    Id = 1,
                    NationalityId = 1,
                    TaxOfficeId = 1,
                    VatPercentId = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-02-07 09:19:25"
                }
            ];
        }

    }

}
