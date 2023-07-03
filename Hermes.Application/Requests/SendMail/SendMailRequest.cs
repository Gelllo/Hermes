using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Application.Requests.SendMail
{
    public record SendMailRequest
    {
        public string UserName { get; set; }
        public string MailSubject { get; set; }
        public string TargetMail { get; set; }
        public string MailBody { get; set; }

        [FromForm]
        public IFormFile? FormFiles { get; set; }
    }
}
