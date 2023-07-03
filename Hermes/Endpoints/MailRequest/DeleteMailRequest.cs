using FastEndpoints;
using Hermes.Application;
using Hermes.Application.Requests.MailRequest;
using Hermes.Application.Responses.MailRequest;

namespace Hermes.Web.Endpoints.MailRequest
{
    public class DeleteMailRequest : EndpointWithoutRequest
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;

        public DeleteMailRequest(ICommandDispatcher dispatcher, ILogger logger)
        {
            _dispatcher = dispatcher;
            _logger = logger;
        }

        public override void Configure()
        {
            Delete("/mailrequests/{MailID}");
            Roles("USER", "MEDIC");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            try
            {
                var req = new DeleteMailRequestRequest() { Id = Route<int>("MailID") };
                await SendAsync(
                    await _dispatcher.Dispatch<DeleteMailRequestRequest, DeleteMailRequestResponse>(req, ct), StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}