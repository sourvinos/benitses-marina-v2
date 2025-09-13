using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace BoatUsages {

    public class CreateValidBoatUsage : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestBoatUsage {
                    Description = Helpers.CreateRandomString(128),
                }
            ];
        }

    }

}
