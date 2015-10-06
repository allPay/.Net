using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
namespace GamePay
{
    public partial class _Default : System.Web.UI.Page
    {
        //private static string AllpayUrl = "https://payment.allpay.com.tw/Cashier/AioCheckOut";//正式
        private static string AllpayUrl = "http://payment-stage.allpay.com.tw/Cashier/AioCheckOut";//測試

        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> testStr = new SortedDictionary<string, string>();
            testStr.Add("MerchantID", "2000132");
            testStr.Add("MerchantTradeNo", "TEST" + new Random().Next(0, 99999).ToString());
            testStr.Add("MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            testStr.Add("PaymentType", "aio");
            testStr.Add("TotalAmount", "100");
            testStr.Add("TradeDesc", "遊戲寶交易測試(測試)");
            testStr.Add("ItemName", "遊戲寶全家立即儲100元(測試)");
            testStr.Add("ReturnURL", "http://www.allpay.com.tw/receive.php");
            testStr.Add("ChoosePayment", "APPBARCODE");

            //新增開立發票參數
            testStr.Add("RelateNumber", "test" + new Random().Next(0, 99999).ToString());
            testStr.Add("CustomerID", "");
            testStr.Add("CustomerIdentifier", "");
            testStr.Add("CustomerName", HttpUtility.UrlEncode("遊戲寶測試"));
            testStr.Add("CustomerAddr", HttpUtility.UrlEncode("臺北市南港區三重路一段"));
            testStr.Add("CustomerPhone", "");
            testStr.Add("CustomerEmail", HttpUtility.UrlEncode("linna.yu@allpay.com.tw"));
            testStr.Add("ClearanceMark", "");
            testStr.Add("TaxType", "1");
            testStr.Add("CarruerType", "3");
            testStr.Add("CarruerNum", "/K+S3WRR");
            testStr.Add("Donation", "2");
            testStr.Add("LoveCode", "");
            testStr.Add("Print", "1");
            testStr.Add("InvoiceItemName", "遊戲寶全家立即儲100元(測試)");
            testStr.Add("InvoiceItemCount", "1");
            testStr.Add("InvoiceItemWord", "項");
            testStr.Add("InvoiceItemPrice", "100");
            testStr.Add("InvoiceItemTaxType", "1");
            testStr.Add("InvoiceRemark", HttpUtility.UrlEncode("GamePay訂單開立電子發票"));
            testStr.Add("DelayDay", "0");
            testStr.Add("InvType", "05");

            string str = string.Empty;
            string str_pre = string.Empty;
            foreach (var test in testStr)
            {
                str += string.Format("&{0}={1}", test.Key, test.Value);
            }
            str_pre += "HashKey=5294y06JbISpM5x9" + str + "&HashIV=v77hoKGq4kWxNNIS";

            string urlEncodeStrPost = HttpUtility.UrlEncode(str_pre);
            string ToLower = urlEncodeStrPost.ToLower();

            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(ToLower));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));//MD5碼 大小寫
            }
            string sCheckMacValue = sBuilder.ToString();
            testStr.Add("CheckMacValue", sCheckMacValue);

            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append("<html><body>").AppendLine();
            sb.Append("<form name='allpayTradeTest'  id='allpayTradeTest' action='" + AllpayUrl + "' method='POST'>").AppendLine();
            foreach (var aa in testStr)
            {
                sb.Append("<input type='hidden' name='" + aa.Key + "' value='" + aa.Value + "'>").AppendLine();
            }

            sb.Append("</form>").AppendLine();
            sb.Append("<script> var theForm = document.forms['allpayTradeTest'];  if (!theForm) { theForm = document.allpayTradeTest; } theForm.submit(); </script>").AppendLine();
            sb.Append("<html><body>").AppendLine();

            Response.Write(sb.ToString());
            Response.End();
        }
    }
}
