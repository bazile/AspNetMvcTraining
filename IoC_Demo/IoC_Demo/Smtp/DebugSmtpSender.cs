using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace IoC_Demo
{
    public class DebugSmtpSender : ISmtpSender
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            using (var message = new MailMessage())
            {
                message.From = new MailAddress("do-not-reply@bookshop.by");
                message.To.Add(new MailAddress("admin@bookshop.by"));
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;
                //message.AlternateViews
                //message.Attachments.Add(new Attachment(...))

                // SMTP - Simple Mail Transfer Protocol (отправка)
                // POP3/IMAP (прием) MailKit
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Host = "smtp.yandex.ru";
                    smtpClient.Port = 443;
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("user", "password");
                    await smtpClient.SendMailAsync(message);
                }
            }
        }

    }
}