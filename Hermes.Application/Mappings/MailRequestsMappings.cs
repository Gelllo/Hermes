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
    public class MailRequestsMappings:Profile
    {
        public MailRequestsMappings()
        {
            CreateMap<MailRequest, MailRequestDTO>()
                .ForMember(dest => dest.DateRequested,
                    opt => opt.MapFrom(src => src.DateRequested.ToString("MM-dd-yyyy")));

            CreateMap<MailRequestDTO, MailRequest>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => DateTime.Parse(src.DateRequested)));

        }
    }
}
