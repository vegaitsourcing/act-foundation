using System;
using System.Net;
using System.Net.Mail;
using ACTFoundation.Core.Models;

namespace ACTFoundation.Core
{
    public static class SmtpHelper
    {
        public static void SendEmail(EmailSettings emailSettings, string name, string email, string contactReason, string text)
        {
            var fromAddress = new MailAddress(emailSettings.SenderEmailAddress);
            var toAddress = new MailAddress(emailSettings.ReceiverEmailAddress);
            const string subject = "ACT Foundation website contact form submission";
            string body = $"Ime: {name}\n Email: {email} \n Razlog kontaktiranja: {contactReason} \n Text: {text}";

            var smtp = new SmtpClient
            {
                Host = emailSettings.ServerAddress,
                Port = emailSettings.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailSettings.SenderEmailAddress, emailSettings.Password)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
