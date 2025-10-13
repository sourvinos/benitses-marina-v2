using System.Collections;
using System.Collections.Generic;

namespace Items {

    public class UpdateValidItem : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Update_Valid_Item();
        }

        private static object[] Update_Valid_Item() {
            return [
                new TestItem {
                    Id = 1,
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
                    IsActive = true,
                    PutAt = "2025-01-01 00:00:00"
                }
            ];
        }

    }

}
