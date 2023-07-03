using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Requests.MailRequest
{
    public record UpdateMailRequestRequest
    {
        public MailRequestDTO MailRequest { get; set; }
    }
}
