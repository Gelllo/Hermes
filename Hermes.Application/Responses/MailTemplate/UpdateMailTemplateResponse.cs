using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Application.Requests;

namespace Hermes.Application.Responses.MailTemplate
{
    public record UpdateMailTemplateResponse
    {
        public MailTemplateDTO MailTemplate { get; set; }
    }
}
