using System.Web.Mvc;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Models;
using AllPay.EInvoice.Integration.Service;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class AllowanceController : Controller
    {
        //
        // GET: /Allowance/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AllowanceViewModel Model)
        {
            //1. 設定開立折讓資訊
            Allowance invc = new Allowance();
            invc.MerchantID = Model.MerchantID;
            invc.InvoiceNo = Model.InvoiceNo;
            invc.allowanceNotify = Model.AllowanceNotify;
            invc.CustomerName = Model.CustomerName;
            invc.NotifyPhone = Model.NotifyPhone;
            invc.NotifyMail = Model.NotifyMail;
            invc.AllowanceAmount = Model.AllowanceAmount;
            invc.Items.Add(new Item()
            {
                ItemName = Model.ItemName,
                ItemPrice = Model.ItemPrice,
                ItemCount = Model.ItemCount,
                ItemWord = Model.ItemWord,
                ItemAmount = Model.ItemAmount
            });

            //2. 初始化發票Service物件
            Invoice<Allowance> inv = new Invoice<Allowance>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);

            //6. 解序列化，還原成物件使用
            //AllowanceReturn obj = new AllowanceReturn();
            //obj = JsonConvert.DeserializeObject<AllowanceReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();
        }
    }
}