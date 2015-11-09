using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    public class AllowanceInvalidViewModel
    {
        public string MerchantID { get; set; }
        public string InvoiceNo { get; set; }
        public string AllowanceNo { get; set; }
        public string Reason { get; set; }
    }
}