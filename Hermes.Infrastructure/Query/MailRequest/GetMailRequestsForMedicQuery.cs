using AutoMapper;
using Hermes.Application;
using Hermes.Application.Requests;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Domain;

namespace Hermes.Infrastructure.Query.MailRequest
{
    public class GetMailRequestsForMedicQuery : IQueryHandler<GetMailRequestsForMedicRequest, GetMailRequestsForMedicResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMailRequestsForMedicQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetMailRequestsForMedicResponse> Handle(GetMailRequestsForMedicRequest query, CancellationToken cancellation)
        {
            return new GetMailRequestsForMedicResponse()
            {
                MailRequests = 
                    _mapper.Map<IEnumerable<MailRequestDTO>>(
                        await _unitOfWork.MailRequestsRepository.GetMailRequestsForMedicAsync(query.UserID))
            };
        }
    }
}