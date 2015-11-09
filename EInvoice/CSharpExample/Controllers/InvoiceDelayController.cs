using System.Web.Mvc;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Models;
using AllPay.EInvoice.Integration.Service;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class InvoiceDelayController : Controller
    {
        //
        // GET: /InvoiceDelay/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(InvoiceDelayViewModel Model)
        {
            //1. 設定觸發或延遲開立發票資訊
            InvoiceDelay invc = new InvoiceDelay();
            invc.MerchantID = Model.MerchantID;
            invc.DelayFlag = Model.DelayFlag;
            invc.RelateNumber = Model.RelateNumber;
            invc.CustomerID = Model.CustomerID;
            invc.CustomerIdentifier = Model.CustomerIdentifier;
            invc.CustomerAddr = Model.CustomerAddr;
            invc.CustomerName = Model.CustomerName;
            invc.CustomerPhone = Model.CustomerPhone;
            invc.CustomerEmail = Model.CustomerEmail;
            invc.ClearanceMark = Model.ClearanceMark;
            invc.TaxType = Model.TaxType;
            invc.SalesAmount = Model.SalesAmount;
            invc.carruerType = Model.CarruerType;
            invc.CarruerNum = Model.CarruerNum;
            invc.Donation = Model.Donation;
            invc.LoveCode = Model.LoveCode;
            invc.Print = Model.Print;
            invc.Items.Add(new Item()
            {
                ItemName = Model.ItemName,
                ItemPrice = Model.ItemPrice,
                ItemCount = Model.ItemCount,
                ItemWord = Model.ItemWord,
                ItemAmount = Model.ItemAmount
            });
            invc.InvoiceRemark = Model.InvoiceRemark;
            invc.DelayDay = Model.DelayDay;
            invc.ECBankID = Model.ECBankID;
            invc.Tsr = Model.Tsr;
            invc.PayType = Model.PayType;
            invc.NotifyURL = Model.NotifyURL;
            invc.invType = Model.InvType;

            //2. 初始化發票Service物件
            Invoice<InvoiceDelay> inv = new Invoice<InvoiceDelay>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);

            //6. 解序列化，還原成物件使用
            //InvoiceDelayReturn obj = new InvoiceDelayReturn();
            //obj = JsonConvert.DeserializeObject<QueryAllowanceReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();
        }
    }
}