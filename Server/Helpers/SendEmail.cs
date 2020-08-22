using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SurcosBlazor.Server.Helpers
{
    public static class SendEmail
    {
        public static void Send(string htmlString,string asunto  ,string receptor)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("sistemasurcos@gmail.com");
                if (!string.IsNullOrEmpty(receptor)) {
                    message.To.Add(new MailAddress(receptor));
                }
              
                message.Subject = asunto;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sistemasurcos@gmail.com", "Dema0703@");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            { }
        }
    }
}
