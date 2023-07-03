using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hermes.Application.Services
{
    public interface IMailService
    {
        public void SendReportEmail(string emailTo, string subject, string body, string userName, IFormFile formFiles);

        public void SendPasswordResetEmail(string emailTo, string token);
    }
}