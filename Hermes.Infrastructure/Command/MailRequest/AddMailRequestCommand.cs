using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application;
using Hermes.Domain;
using AutoMapper;
using Hermes.Application.Requests;

namespace Hermes.Infrastructure.Command.MailRequest
{
    public class AddMailRequestCommand : ICommandHandler<AddMailRequestRequest, AddMailRequestResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddMailRequestCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<AddMailRequestResponse> Handle(AddMailRequestRequest request, CancellationToken cancellation)
        {
            await _unitOfWork.MailRequestsRepository.InsertMailRequest(_mapper.Map<Domain.MailRequest>(request.MailRequest));
            return new AddMailRequestResponse();
        }
    }
}
