using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Application.Requests;
using Hermes.Domain;

namespace Hermes.Application.Mappings
{
    public class MailTemplatesMappings:Profile
    {
        public MailTemplatesMappings()
        {
            CreateMap<MailTemplate, MailTemplateDTO>().ReverseMap();
        }
    }
}
