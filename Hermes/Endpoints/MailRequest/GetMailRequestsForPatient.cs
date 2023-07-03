using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;

namespace Hermes.Web.Endpoints.MailRequest
{
    public class GetMailRequestsForPatient : EndpointWithoutRequest
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetMailRequestsForPatient(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Get("/mailrequests/patient/{PatientID}");
            Roles("USER");
        }

        public override async Task HandleAsync( CancellationToken ct)
        {
            try
            {
                var req = new GetMailRequestsForPatientRequest() { UserID = Route<string>("PatientID") };
                await SendAsync(
                    await _dispatcher.Dispatch<GetMailRequestsForPatientRequest, GetMailRequestsForPatientResponse>(req, ct));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}