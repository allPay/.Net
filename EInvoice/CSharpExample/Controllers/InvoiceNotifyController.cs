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
    public class InvoiceNotifyController : Controller
    {
        //
        // GET: /InvoiceNotify/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(InvoiceNotifyViewModel Model)
        {
            ////1. 設定發送通知資訊
            InvoiceNotify invn = new InvoiceNotify();
            invn.MerchantID = Model.MerchantID;
            invn.InvoiceNo = Model.InvoiceNo;
            invn.AllowanceNo = Model.AllowanceNo;
            invn.Phone = Model.Phone;
            invn.NotifyMail = Model.NotifyMail;
            invn.notify = Model.Notify;
            invn.invoiceTag = Model.InvoiceTag;
            invn.notified = Model.Notified;


            //2. 初始化發票Service物件
            Invoice<InvoiceNotify> inv = new Invoice<InvoiceNotify>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invn);

            //6. 解序列化，還原成物件使用
            //InvoiceNotifyReturn obj = new InvoiceNotifyReturn();
            //obj = JsonConvert.DeserializeObject<InvoiceNotifyReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;


            return View();
        }

    }
}
