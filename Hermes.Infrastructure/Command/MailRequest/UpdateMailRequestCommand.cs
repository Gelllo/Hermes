using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hermes.Application;
using Hermes.Application.Requests;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Responses.MailRequest;

namespace Hermes.Infrastructure.Command.MailRequests
{
    public class UpdateMailRequestCommand : ICommandHandler<UpdateMailRequestRequest, UpdateMailRequestResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMailRequestCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<UpdateMailRequestResponse> Handle(UpdateMailRequestRequest request, CancellationToken cancellation)
        {
            var record = await _unitOfWork.MailRequestsRepository.GetMailRequestAsync(request.MailRequest.Id);

            if (record == null)
            {
                throw new Exception("Record doesn't exist");
            }

            record.DoctorUsername = request.MailRequest.DoctorUsername;
            record.PatientUsername = request.MailRequest.PatientUsername;
            record.Status = request.MailRequest.Status;
            record.ReportRequested = request.MailRequest.ReportRequested;

            DateTime.TryParseExact(request.MailRequest.DateRequested, "MM-dd-yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime result);

            record.DateRequested = result;

            return new UpdateMailRequestResponse()
                { MailRequest = _mapper.Map<MailRequestDTO>(await _unitOfWork.MailRequestsRepository.UpdateMailRequest(record)) };
        }
    }
}