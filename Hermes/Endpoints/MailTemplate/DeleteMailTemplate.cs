using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailRequest;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Domain;

namespace Hermes.Web.Endpoints.MailTemplate
{
    public class DeleteMailTemplate : EndpointWithoutRequest
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public DeleteMailTemplate(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Delete("/mailtemplates/{MailRequestID}");
            Roles("USER", "MEDIC");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new DeleteMailTemplateRequest() { Id = Route<int>("MailRequestID") };
                await SendAsync(
                    await _dispatcher.Dispatch<DeleteMailTemplateRequest, DeleteMailTemplateResponse>(req, ct), StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}