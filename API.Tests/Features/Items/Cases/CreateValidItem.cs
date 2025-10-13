using System.Collections;
using System.Collections.Generic;

namespace Items {

    public class CreateValidItem : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Create_Valid_Item();
        }

        private static object[] Create_Valid_Item() {
            return [
                new TestItem {
                    HullTypeId = 1,
                    PeriodTypeId = 1,
                    SeasonTypeId = 1,
                    Code = "12ABC",
                    Description = "DESCRIPTION",
                    EnglishDescription = "ENGLISH DESCRIPTION",
                    Length = 3.5M,
                    IsIndividual = true,
                    NetAmount = 100,
                    VatPercent = 24,
                    IsActive = true
                }
            ];
        }

    }

}
