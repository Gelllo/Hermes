using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;

namespace Hermes.Web.Endpoints.MailTemplate
{
    public class GetMailTemplates : EndpointWithoutRequest
    {
        private IQueryDispatcher _dispatcher;
        private ILogger _logger;

        public GetMailTemplates(IQueryDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Get("/mailtemplates/{UserID}");
            Roles("USER", "MEDIC");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new GetMailTemplatesRequest() { UserID = Route<string>("UserID") };
                await SendAsync(
                    await _dispatcher.Dispatch<GetMailTemplatesRequest, GetMailTemplatesResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}