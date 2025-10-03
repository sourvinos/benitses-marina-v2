using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace Nationalities {

    public class UpdateValidNationality : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestNationality {
                    Id = 1,
                    Description = Helpers.CreateRandomString(128),
                    Code = Helpers.CreateRandomString(10),
                    PutAt = "2023-12-23 00:00:00"
                }
            ];
        }

    }

}
