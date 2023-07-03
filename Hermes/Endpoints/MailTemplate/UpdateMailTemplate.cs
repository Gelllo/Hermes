using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;

namespace Hermes.Web.Endpoints.MailTemplate
{
    public class UpdateMailTemplate : Endpoint<UpdateMailTemplateRequest, UpdateMailTemplateResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public UpdateMailTemplate(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Put("/mailtemplates/{UserID}");
            Roles("USER", "MEDIC");
        }

        public override async Task HandleAsync(UpdateMailTemplateRequest req, CancellationToken ct)
        {
            try
            {
                await SendAsync(
                    await _dispatcher.Dispatch<UpdateMailTemplateRequest, UpdateMailTemplateResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}