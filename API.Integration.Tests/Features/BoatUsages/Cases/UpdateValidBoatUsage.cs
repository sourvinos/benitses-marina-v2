using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace BoatUsages {

    public class UpdateValidBoatUsage : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return new object[] {
                new TestBoatUsage {
                    Id = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-08-08 06:53:26"
                }
            };
        }

    }

}
