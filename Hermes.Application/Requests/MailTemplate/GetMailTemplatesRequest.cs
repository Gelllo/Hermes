﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Requests.MailTemplate
{
    public record GetMailTemplatesRequest
    {
        public string UserID { get; set; }
    }
}
