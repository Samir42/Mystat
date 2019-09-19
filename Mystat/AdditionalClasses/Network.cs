using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mystat.AdditionalClasses
{
    public class Network
    {
        public static void SendMail(string to,string subject,string body)
        {
            Task.Run(() =>
            {
                string mailBodyhtml =
                    $"<h1>{subject}</h1>";
                var msg = new MailMessage("samirhemzeyev2001@gmail.com", to, subject, body);
                msg.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential("samirhemzeyev2001@gmail.com", "_socket_42");
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            });
        }
    }
}
