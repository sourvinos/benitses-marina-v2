using System.Collections;
using System.Collections.Generic;
using API.Features.Sales;

namespace Sales {

    public class CreateInvalidSale : IEnumerable<object[]> {

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator() {
            yield return Customer_Must_Exist();
            yield return DocumentType_Must_Exist();
            yield return PaymentMethod_Must_Exist();
            yield return Discount_Percent_And_Discount_Amount_Not_Accepted();
        }

        private static object[] Customer_Must_Exist() {
            return [
                new TestSale {
                    StatusCode = 459,
                    Date = "2025-01-01",
                    InvoiceNo = 3,
                    CustomerId = 9999,
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

        private static object[] DocumentType_Must_Exist() {
            return [
                new TestSale {
                    StatusCode = 460,
                    Date = "2025-01-01",
                    InvoiceNo = 3,
                    CustomerId = 1,
                    DocumentTypeId = 999,
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

        private static object[] PaymentMethod_Must_Exist() {
            return [
                new TestSale {
                    StatusCode = 461,
                    Date = "2025-01-01",
                    InvoiceNo = 3,
                    CustomerId = 1,
                    DocumentTypeId = 1,
                    PaymentMethodId = 99,
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

        private static object[] Discount_Percent_And_Discount_Amount_Not_Accepted() {
            return [
                new TestSale {
                    StatusCode = 462,
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
                            DiscountAmount = 19,
                            VatPercent = 24
                         }
                    ]
                }
            ];
        }

    }

}
