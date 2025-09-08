using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace HullTypes {

    public class CreateValidHullType : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestHullType {
                    Description = Helpers.CreateRandomString(128),
                }
            ];
        }

    }

}
