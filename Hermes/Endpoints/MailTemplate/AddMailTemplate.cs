using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;

namespace Hermes.Web.Endpoints.MailTemplate
{
    public class AddMailTemplate : Endpoint<AddMailTemplateRequest, AddMailTemplateResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public AddMailTemplate(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/mailtemplates/{UserID}");
            Roles("USER", "MEDIC");
        }

        public override async Task HandleAsync(AddMailTemplateRequest req, CancellationToken ct)
        {
            try
            {
                await SendAsync(
                    await _dispatcher.Dispatch<AddMailTemplateRequest, AddMailTemplateResponse>(req, ct), StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }
    }
}