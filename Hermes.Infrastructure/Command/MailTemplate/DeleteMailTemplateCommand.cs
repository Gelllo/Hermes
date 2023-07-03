using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Hermes.Infrastructure.Command.MailTemplates
{
    public class DeleteMailTemplateCommand : ICommandHandler<DeleteMailTemplateRequest, DeleteMailTemplateResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMailTemplateCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteMailTemplateResponse> Handle(DeleteMailTemplateRequest request, CancellationToken cancellation)
        {
            _unitOfWork.MailTemplatesRepository.DeleteMailTemplate(request.Id);
            return new DeleteMailTemplateResponse();
        }
    }
}
