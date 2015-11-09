using AllPay.EInvoice.Integration.Enumeration;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    public class InvoiceDelayViewModel
    {
        public string MerchantID { get; set; }
        public DelayFlagEnum DelayFlag { get; set; }
        public string RelateNumber { get; set; }
        public string CustomerID { get; set; }
        public string CustomerIdentifier { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddr { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public CustomsClearanceMarkEnum ClearanceMark { get; set; }
        public TaxTypeEnum TaxType { get; set; }
        public string SalesAmount { get; set; }
        public CarruerTypeEnum CarruerType { get; set; }
        public string CarruerNum { get; set; }
        public DonationEnum Donation { get; set; }
        public string LoveCode { get; set; }
        public PrintEnum Print { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
        public string ItemWord { get; set; }
        public string ItemPrice { get; set; }
        public string ItemTaxType { get; set; }
        public string ItemAmount { get; set; }
        public string InvoiceRemark { get; set; }
        public string DelayDay { get; set; }
        public string ECBankID { get; set; }
        public string Tsr { get; set; }
        public PayTypeEnum PayType { get; set; }
        public string NotifyURL { get; set; }
        public TheWordTypeEnum InvType { get; set; }
    }
}