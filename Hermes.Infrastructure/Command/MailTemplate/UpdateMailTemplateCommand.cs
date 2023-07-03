using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Application;
using Hermes.Application.Requests;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailTemplate;

namespace Hermes.Infrastructure.Command.MailTemplates
{
    public class UpdateMailTemplateCommand : ICommandHandler<UpdateMailTemplateRequest, UpdateMailTemplateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMailTemplateCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<UpdateMailTemplateResponse> Handle(UpdateMailTemplateRequest request, CancellationToken cancellation)
        {
            var record = await _unitOfWork.MailTemplatesRepository.GetMailTemplateAsync(request.MailTemplate.Id);

            if (record == null)
            {
                throw new Exception("Record doesn't exist");
            }

            record.MailBody = request.MailTemplate.MailBody;
            record.MailSubject = request.MailTemplate.MailSubject;
            record.Name = request.MailTemplate.Name;
            record.SenderEmail = request.MailTemplate.SenderEmail;
            record.TargetEmail = request.MailTemplate.TargetEmail;

            return new UpdateMailTemplateResponse()
                { MailTemplate = _mapper.Map<MailTemplateDTO>(await _unitOfWork.MailTemplatesRepository.UpdateMailTemplate(record)) };
        }
    }
}
