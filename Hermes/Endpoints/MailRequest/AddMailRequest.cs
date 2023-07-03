using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Responses.MailRequest;

namespace Hermes.Web.Endpoints.MailRequest
{
    public class AddMailRequest : Endpoint<AddMailRequestRequest, AddMailRequestResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public AddMailRequest(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Post("/mailrequests");
            Roles("MEDIC");
        }

        public override async Task HandleAsync(AddMailRequestRequest req, CancellationToken ct)
        {
            try
            {
                await SendAsync(
                    await _dispatcher.Dispatch<AddMailRequestRequest, AddMailRequestResponse>(req, ct), StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
            
        }
    }
}