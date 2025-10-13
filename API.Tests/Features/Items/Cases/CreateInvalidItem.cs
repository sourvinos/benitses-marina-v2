using System.Collections;
using System.Collections.Generic;

namespace Items {

    public class CreateInvalidItem : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return HullType_Must_Exist();
            yield return HullType_Must_Be_Active();
            yield return PeriodType_Must_Exist();
            yield return PeriodType_Must_Be_Active();
            yield return SeasonType_Must_Exist();
            yield return SeasonType_Must_Be_Active();
        }

        private static object[] HullType_Must_Exist() {
            return [
                new TestItem {
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
                    IsActive = true
                }
            ];
        }

        private static object[] HullType_Must_Be_Active() {
            return [
                new TestItem {
                    StatusCode = 451,
                    HullTypeId = 3,
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

        private static object[] PeriodType_Must_Exist() {
            return [
                new TestItem {
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

        private static object[] PeriodType_Must_Be_Active() {
            return [
                new TestItem {
                    StatusCode = 455,
                    HullTypeId = 1,
                    PeriodTypeId = 4,
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
                new TestItem {
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

        private static object[] SeasonType_Must_Be_Active() {
            return [
                new TestItem {
                    StatusCode = 456,
                    HullTypeId = 1,
                    PeriodTypeId = 1,
                    SeasonTypeId = 4,
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