using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Hermes.Application.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using MimeKit;
using MimeKit.Text;
using ContentDisposition = MimeKit.ContentDisposition;

namespace Hermes.Infrastructure.Services
{
    public class MailService:IMailService
    {
        public MailService()
        {
            
        }

        public void SendReportEmail(string emailTo, string subject, string body, string userName, IFormFile file)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("diabilly.app@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;

            byte[] fileBytes;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            bodyBuilder.Attachments.Add(file.FileName, fileBytes, MimeKit.ContentType.Parse(MediaTypeNames.Application.Pdf));
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("diabilly.app@gmail.com", "usuekymflyrihmok");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendPasswordResetEmail(string emailTo, string token)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("diabilly.app@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = "DiaBilly Account Password Reset";
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = "<div>" +
                       "<p> You requested to reset your password, proceed with this link: <a href=\"http://localhost:4200/presentation/resetpassword?token=" +
                       token +
                       "\"> DiaBilly </a></p>" +
                       "<p>If that was not you, please ignore this mail." +
                       "</div>"
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("diabilly.app@gmail.com", "usuekymflyrihmok");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
