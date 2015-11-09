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
    public class InvoiceTriggerController : Controller
    {
        //
        // GET: /InvoiceTrigger/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(InvoiceTriggerViewModel Model)
        {
            //1. 設定付款完成觸發或延遲開立發票資訊
            InvoiceTrigger invt = new InvoiceTrigger();
            invt.MerchantID = Model.MerchantID;
            invt.Tsr = Model.Tsr;
            invt.PayType = Model.PayType;

            //2. 初始化發票Service物件
            Invoice<InvoiceTrigger> inv = new Invoice<InvoiceTrigger>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invt);

            //6. 解序列化，還原成物件使用
            //InvoiceTriggerReturn obj = new InvoiceTriggerReturn();
            //obj = JsonConvert.DeserializeObject<InvoiceTriggerReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;


            return View();
        }

    }
}
