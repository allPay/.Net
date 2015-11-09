using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllPay.EInvoice.Integration.Enumeration;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    public class InvoiceInvalidViewModel
    {
        public string MerchantID { get; set; }
        public string InvoiceNumber { get; set; }
        public string Reason { get; set; }
    }
}