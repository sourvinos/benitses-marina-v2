using System.Collections;
using System.Collections.Generic;
using API.Features.Sales;

namespace Sales {

    public class CreateValidSale : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Create_Valid_Sale_Without_Discount();
            yield return Create_Valid_Sale_With_Discount_Percent();
            yield return Create_Valid_Sale_With_Discount_Amount();
        }

        private static object[] Create_Valid_Sale_Without_Discount() {
            return [
                new TestSale {
                    Date = "2025-01-01",
                    InvoiceNo = 3,
                    CustomerId = 1,
                    DocumentTypeId = 1,
                    PaymentMethodId = 1,
                    Items = [
                        new TestSaleItem {
                            ItemId = 1,
                            Qty = 1,
                            UnitItem = 10,
                            DiscountPercent = 0,
                            DiscountAmount = 0,
                            VatPercent = 24
                         }
                    ]
                }
            ];
        }

        private static object[] Create_Valid_Sale_With_Discount_Percent() {
            return [
                new TestSale {
                    Date = "2025-01-01",
                    InvoiceNo = 3,
                    CustomerId = 1,
                    DocumentTypeId = 1,
                    PaymentMethodId = 1,
                    Items = [
                        new TestSaleItem {
                            ItemId = 1,
                            Qty = 2,
                            UnitItem = 10,
                            DiscountPercent = 5,
                            DiscountAmount = 0,
                            VatPercent = 24
                         }
                    ]
                }
            ];
        }

        private static object[] Create_Valid_Sale_With_Discount_Amount() {
            return [
                new TestSale {
                    Date = "2025-01-01",
                    InvoiceNo = 3,
                    CustomerId = 1,
                    DocumentTypeId = 1,
                    PaymentMethodId = 1,
                    Items = [
                        new TestSaleItem {
                            ItemId = 1,
                            Qty = 2,
                            UnitItem = 10,
                            DiscountPercent = 0,
                            DiscountAmount = 7,
                            VatPercent = 24
                         }
                    ]
                }
            ];
        }

    }

}
