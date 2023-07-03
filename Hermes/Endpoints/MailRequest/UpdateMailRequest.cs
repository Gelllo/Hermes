using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Responses.MailRequest;

namespace Hermes.Web.Endpoints.MailRequest
{
    public class UpdateMailRequest : Endpoint<UpdateMailRequestRequest, UpdateMailRequestResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public UpdateMailRequest(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Put("/mailrequests/{UserID}");
            Roles("USER");
        }

        public override async Task HandleAsync(UpdateMailRequestRequest req, CancellationToken ct)
        {
            try
            {
                await SendAsync(
                    await _dispatcher.Dispatch<UpdateMailRequestRequest, UpdateMailRequestResponse>(req, ct), StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}