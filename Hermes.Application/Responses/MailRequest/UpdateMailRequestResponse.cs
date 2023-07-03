using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Application.Requests;

namespace Hermes.Application.Responses.MailRequest
{
    public record UpdateMailRequestResponse
    {
        public MailRequestDTO MailRequest { get; set; }
    }
}
