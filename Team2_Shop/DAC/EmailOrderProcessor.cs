using Team2_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Team2_Shop.DAC
{
    public class EmailSettings
    {
        public string MailToAddress = "inhee73@hanmail.net"; //자기 확인할 메일
        public string MailFromAddress = "danawa@gudi.com";
        public bool UseSsl = true;
        public string Username = "ihlee@anyform.co.kr";      //자기의 Gmail
        public string Password = "******";                  //자기의 Gmail 비밀번호
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }

    public class EmailOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        // 주문받고 처리하는곳
        public void ProcessOrder(Cart cart, ShipInfo orderInfo)
        {
            using (var smtpClient = new SmtpClient())
            {

                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                          emailSettings.Password);

                StringBuilder body = new StringBuilder()
                    .AppendLine("주문처리가 완료되었습니다.")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Product_Price * line.Qty;
                    body.AppendFormat("         - {0} x {1} (subtotal: {2:c})", 
                                      line.Product.Product_Name, line.Qty,
                                      subtotal);
                    body.AppendLine();
                }
                body.AppendLine();

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                    .AppendLine()
                    .AppendLine("---")
                    .AppendLine("배송지정보:")
                    .AppendLine(orderInfo.Addr1)
                    .AppendLine(orderInfo.Addr2 ?? "")
                    .AppendLine(orderInfo.Message ?? "")
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                                       emailSettings.MailFromAddress,   // From
                                       emailSettings.MailToAddress,     // To
                                       "신규 주문 완료!",                // Subject
                                       body.ToString());                // Body

                smtpClient.Send(mailMessage);
            }
        }
    }
}