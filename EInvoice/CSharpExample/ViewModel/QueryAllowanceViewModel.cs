using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AllPay.EInvoice.Integration.Models;

namespace AllPay.Einvoice.Integration.Sample.ViewModel
{
    /// <summary>
    /// 查詢折讓明細
    /// </summary>
    public class QueryAllowanceViewModel
    {
        public string MerchantID { get; set; }
        public string InvoiceNo { get; set; }
        public string AllowanceNo { get; set; }
    }
}