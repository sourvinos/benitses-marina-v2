using System.Collections;
using System.Collections.Generic;
using Infrastructure;

namespace DocumentTypes {

    public class CreateValidDocumentType : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return ValidRecord();
        }

        private static object[] ValidRecord() {
            return [
                new TestDocumentType {
                    DiscriminatorId = 1,
                    Abbreviation = Helpers.CreateRandomString(5),
                    AbbreviationEn = Helpers.CreateRandomString(5),
                    AbbreviationDataUp = Helpers.CreateRandomString(15),
                    Description = Helpers.CreateRandomString(128),
                    Batch = Helpers.CreateRandomString(5),
                    Customers = "+",
                    Suppliers = ""
                }
            ];
        }

    }

}
