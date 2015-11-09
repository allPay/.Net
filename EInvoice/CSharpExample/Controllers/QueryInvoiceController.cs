using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Models;
using AllPay.EInvoice.Integration.Service;
using Newtonsoft.Json;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class QueryInvoiceController : Controller
    {
        //
        // GET: /QueryInvoice/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(QueryInvoiceViewModel model)
        {
            //1. 設定開立發票資訊
            QueryInvoice qinv = new QueryInvoice();
            qinv.MerchantID = model.MerchantID;
            qinv.RelateNumber = model.RelateNumber;

            //2. 初始化發票Service物件
            Invoice<QueryInvoice> inv = new Invoice<QueryInvoice>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(qinv);

            //6. 解序列化，還原成物件使用
            //QueryInvoiceReturn obj = new QueryInvoiceReturn();
            //obj = JsonConvert.DeserializeObject<QueryInvoiceReturn>(json);
            //obj.XXX;
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();
        }
    }
}
