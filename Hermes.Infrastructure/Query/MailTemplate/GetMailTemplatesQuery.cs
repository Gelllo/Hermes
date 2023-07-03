using AutoMapper;
using Hermes.Application;
using Hermes.Application.Requests;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Domain;

namespace Hermes.Infrastructure.Query.MailTemplate
{
    public class GetMailTemplatesQuery : IQueryHandler<GetMailTemplatesRequest, GetMailTemplatesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMailTemplatesQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }


        public async Task<GetMailTemplatesResponse> Handle(GetMailTemplatesRequest query, CancellationToken cancellation)
        {
            return new GetMailTemplatesResponse()
            {
                MailTemplates =
                    _mapper.Map<IEnumerable<MailTemplateDTO>>(
                        await _unitOfWork.MailTemplatesRepository.GetMailTemplatesAsync(query.UserID))
            };
        }
    }
}