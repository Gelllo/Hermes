﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Requests.MailTemplate
{
    public record DeleteMailTemplateRequest
    {
        public int Id { get; set; }
    }
}
