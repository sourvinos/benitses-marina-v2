using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace SeasonTypes {

    public class UpdateValidSeasonType : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestSeasonType {
                    Id = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-01-01 00:00:00"
                }
            ];
        }

    }

}
