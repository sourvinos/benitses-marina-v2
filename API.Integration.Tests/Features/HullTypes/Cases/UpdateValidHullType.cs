using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace HullTypes {

    public class UpdateValidHullType : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestHullType {
                    Id = 1,
                    Description = Helpers.CreateRandomString(128),
                    PutAt = "2025-08-08 06:19:46"
                }
            ];
        }

    }

}
