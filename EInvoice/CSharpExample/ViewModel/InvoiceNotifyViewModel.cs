using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllPay.EInvoice.Integration.Enumeration;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    public class InvoiceNotifyViewModel
    {
        public string MerchantID { get; set; }
        public string InvoiceNo { get; set; }
        public string AllowanceNo { get; set; }
        public string Phone { get; set; }
        public string NotifyMail { get; set; }
        public InvoiceNotifyEnum Notify { get; set; }
        public InvoiceTagEnum InvoiceTag { get; set; }
        public NotifiedObjectEnum Notified { get; set; }
    }
}