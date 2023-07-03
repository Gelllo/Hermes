using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;

namespace Hermes.Web.Endpoints.MailRequest
{
    public class GetMailRequestsForMedic : EndpointWithoutRequest
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetMailRequestsForMedic(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Get("/mailrequests/medic/{MedicID}");
            Roles("MEDIC");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new GetMailRequestsForMedicRequest() { UserID = Route<string>("MedicID") };
                await SendAsync(
                    await _dispatcher.Dispatch<GetMailRequestsForMedicRequest, GetMailRequestsForMedicResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}