using AllPay.EInvoice.Integration.Enumeration;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    public class InvoiceCreateViewModel
    {
        public string MerchantID { get; set; }
        public string RelateNumber { get; set; }
        public string CustomerID { get; set; }
        public string CustomerIdentifier { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddr { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public CustomsClearanceMarkEnum ClearanceMark { get; set; }
        public PrintEnum Print { get; set; }
        public DonationEnum Donation { get; set; }
        public string LoveCode { get; set; }
        public CarruerTypeEnum CarruerType { get; set; }
        public string CarruerNum { get; set; }
        public TaxTypeEnum TaxType { get; set; }
        public string SalesAmount { get; set; }
        public string InvoiceRemark { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
        public string ItemWord { get; set; }
        public string ItemPrice { get; set; }
        public string ItemTaxType { get; set; }
        public string ItemAmount { get; set; }
        public TheWordTypeEnum InvType { get; set; }
        public VatEnum vat { get; set; }
        public string InvCreateDate { get; set; }
        public ItemCollection Items { get; set; }
        public string AllPayMid { get; set; }
    }
}