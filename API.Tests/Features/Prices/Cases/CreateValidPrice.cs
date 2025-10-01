using System.Collections;
using System.Collections.Generic;

namespace Prices {

    public class CreateValidPrice : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Create_Valid_Price();
        }

        private static object[] Create_Valid_Price() {
            return [
                new TestPrice {
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
