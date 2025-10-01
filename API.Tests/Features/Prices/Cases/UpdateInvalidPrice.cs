using System.Collections;
using System.Collections.Generic;

namespace Prices {

    public class UpdateInvalidPrice : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return HullType_Must_Exist();
            yield return PeriodType_Must_Exist();
            yield return SeasonType_Must_Exist();
        }

        private static object[] HullType_Must_Exist() {
            return [
                new TestPrice {
                    Id = 1,
                    StatusCode = 451,
                    HullTypeId = 99,
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

        private static object[] PeriodType_Must_Exist() {
            return [
                new TestPrice {
                    Id = 1,
                    StatusCode = 455,
                    HullTypeId = 1,
                    PeriodTypeId = 99,
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

        private static object[] SeasonType_Must_Exist() {
            return [
                new TestPrice {
                    Id = 1,
                    StatusCode = 456,
                    HullTypeId = 1,
                    PeriodTypeId = 1,
                    SeasonTypeId = 99,
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
