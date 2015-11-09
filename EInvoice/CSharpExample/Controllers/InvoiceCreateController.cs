using System.Web.Mvc;
using AllPay.Einvoice.Integration.Sample.ViewModel;
using AllPay.EInvoice.Integration.Models;
using AllPay.EInvoice.Integration.Service;

namespace AllPay.Einvoice.Integration.Sample.Controllers
{
    public class InvoiceCreateController : Controller
    {
        //
        // GET: /InvoiceCreate/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(InvoiceCreateViewModel Model)
        {
            //1. 設定開立發票資訊
            InvoiceCreate invc = new InvoiceCreate();
            invc.MerchantID = Model.MerchantID;
            invc.RelateNumber = Model.RelateNumber;
            invc.AllPayMid = Model.AllPayMid;
            invc.CarruerNum = Model.CarruerNum;
            invc.ClearanceMark = Model.ClearanceMark;
            invc.carruerType = Model.CarruerType;
            invc.CarruerNum = Model.CarruerNum;
            invc.Print = Model.Print;
            invc.Donation = Model.Donation;
            invc.CustomerID = Model.CustomerID;
            invc.CustomerIdentifier = Model.CustomerIdentifier;
            invc.CustomerAddr = Model.CustomerAddr;
            invc.CustomerName = Model.CustomerName;
            invc.CustomerPhone = Model.CustomerPhone;
            invc.CustomerEmail = Model.CustomerEmail;
            invc.SalesAmount = Model.SalesAmount;
            invc.LoveCode = Model.LoveCode;
            invc.vat = Model.vat;
            invc.TaxType = Model.TaxType;
            invc.invType = Model.InvType;

            invc.Items.Add(new Item()
            {
                ItemName = Model.ItemName,
                ItemPrice = Model.ItemPrice,
                ItemCount = Model.ItemCount,
                ItemWord = Model.ItemWord,
                ItemAmount = Model.ItemAmount
            });

            //2. 初始化發票Service物件
            Invoice<InvoiceCreate> inv = new Invoice<InvoiceCreate>();

            //3. 指定測試環境, 上線時請記得改Prod
            inv.Environment = EInvoice.Integration.Enumeration.EnvironmentEnum.Stage;

            //4. 設定歐付寶提供的 Key 和 IV
            inv.HashIV = "q9jcZX8Ib9LM8wYk";
            inv.HashKey = "ejCk326UnaZWKisg";

            //5. 執行API的回傳結果(JSON)字串
            string json = inv.post(invc);

            //6. 解序列化，還原成物件使用
            //InvoiceCreateReturn obj = new InvoiceCreateReturn();
            //obj = JsonConvert.DeserializeObject<InvoiceCreateReturn>(json);
            //obj.XXX;
            // ...

            ViewBag.message = json;

            return View();
        }
    }
}