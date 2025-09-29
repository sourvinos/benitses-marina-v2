using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace SeasonTypes {

    public class CreateValidSeasonType : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestSeasonType {
                    Description = Helpers.CreateRandomString(128),
                }
            ];
        }

    }

}
