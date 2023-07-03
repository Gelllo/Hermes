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
    public class GetMailRequestsForPatientQuery : IQueryHandler<GetMailRequestsForPatientRequest, GetMailRequestsForPatientResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMailRequestsForPatientQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetMailRequestsForPatientResponse> Handle(GetMailRequestsForPatientRequest query, CancellationToken cancellation)
        {
            return new GetMailRequestsForPatientResponse()
            {
                MailRequests =
                    _mapper.Map<IEnumerable<MailRequestDTO>>(
                        await _unitOfWork.MailRequestsRepository.GetMailRequestsForPatientAsync(query.UserID))
            };
        }
    }
}