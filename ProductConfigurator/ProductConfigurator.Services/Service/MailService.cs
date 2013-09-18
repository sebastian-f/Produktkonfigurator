using ProductConfigurator.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ProductConfigurator.Services.Service
{
    public class MailService : IMailService
    {
        void IMailService.SendMail(string toEmailAddress, string toName, string subject, string body){
            MailAddress fromAddress = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["EmailFromName"].ToString());
            MailAddress toAddress = new MailAddress(toEmailAddress, toName);

              
             SmtpClient smtp = new System.Net.Mail.SmtpClient();

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }


    }
}
