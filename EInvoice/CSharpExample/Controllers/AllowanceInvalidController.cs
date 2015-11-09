using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllPay.EInvoice.Integration.Models;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Service;
using Newtonsoft.Json;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class AllowanceInvalidController : Controller
    {
        //
        // GET: /AllowanceInvalid/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AllowanceInvalidViewModel Model)
        {
            //1. 設定開立折讓作廢資訊
            AllowanceInvalid invc = new AllowanceInvalid();
            invc.MerchantID = Model.MerchantID;
            invc.InvoiceNo = Model.InvoiceNo;
            invc.AllowanceNo = Model.AllowanceNo;
            invc.Reason = Model.Reason;

            //2. 初始化發票Service物件
            Invoice<AllowanceInvalid> inv = new Invoice<AllowanceInvalid>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);

            //6. 解序列化，還原成物件使用
            //AllowanceInvalidReturn obj = new AllowanceInvalidReturn();
            //obj = JsonConvert.DeserializeObject<AllowanceInvalidReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();

        }

    }
}
