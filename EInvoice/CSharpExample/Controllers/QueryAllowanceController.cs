using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Models;
using AllPay.EInvoice.Integration.Service;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class QueryAllowanceController : Controller
    {
        //
        // GET: /QueryAllowance/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(QueryAllowanceViewModel model)
        {
            //1. 設定開立折讓資訊
            QueryAllowance qa = new QueryAllowance();
            qa.MerchantID = model.MerchantID;
            qa.InvoiceNo = model.InvoiceNo;
            qa.AllowanceNo = model.AllowanceNo;

            //2. 初始化發票Service物件
            Invoice<QueryAllowance> inv = new Invoice<QueryAllowance>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qa);

            //6. 解序列化，還原成物件使用
            //QueryAllowanceReturn obj = new QueryAllowanceReturn();
            //obj = JsonConvert.DeserializeObject<QueryAllowanceReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();
        }
    }
}
