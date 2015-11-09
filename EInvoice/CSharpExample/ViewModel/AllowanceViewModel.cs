using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllPay.EInvoice.Integration.Models;
using AllPay.EInvoice.Integration.Enumeration;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    public class AllowanceViewModel
    {
        public string MerchantID { get; set; }
        public string InvoiceNo { get; set; }
        public AllowanceNotifyEnum AllowanceNotify { get; set; }
        public string CustomerName { get; set; }
        public string NotifyMail { get; set; }
        public string NotifyPhone { get; set; }
        public string AllowanceAmount { get; set; }
        public string ItemName { get; set; }
        public int ItemCount { get; set; }
        public string ItemWord { get; set; }
        public string ItemPrice { get; set; }
        public string ItemTaxType { get; set; }
        public string ItemAmount { get; set; }
    }
}