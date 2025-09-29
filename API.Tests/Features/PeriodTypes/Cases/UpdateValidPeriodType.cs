using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace PeriodTypes {

    public class UpdateValidPeriodType : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestPeriodType {
                    Id = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-01-01 00:00:00"
                }
            ];
        }

    }

}
