using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Application;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Domain;


namespace Hermes.Infrastracture.Database.Command.GlucoseRecordsCommands
{
    public class AddMailTemplateCommand : ICommandHandler<AddMailTemplateRequest, AddMailTemplateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddMailTemplateCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<AddMailTemplateResponse> Handle(AddMailTemplateRequest request, CancellationToken cancellation)
        {
            await _unitOfWork.MailTemplatesRepository.InsertMailTemplate(
                _mapper.Map<MailTemplate>(request.MailTemplate));
            return new AddMailTemplateResponse();
        }
    }
}