using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Requests.SendMail
{
    public record SendResetPasswordMailRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
