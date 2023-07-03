using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Hermes.Infrastructure.Command.MailRequests
{
    public class DeleteMailRequestCommand : ICommandHandler<DeleteMailRequestRequest, DeleteMailRequestResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMailRequestCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DeleteMailRequestResponse> Handle(DeleteMailRequestRequest request, CancellationToken cancellation)
        {
            _unitOfWork.MailRequestsRepository.DeleteMailRequest(request.Id);
            return new DeleteMailRequestResponse();
        }
    }
}