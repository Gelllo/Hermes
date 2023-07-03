using FastEndpoints;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Application;
using Hermes.Application.Requests;
using Hermes.Application.Requests.SendMail;
using Hermes.Application.Responses;
using Hermes.Application.Responses.SendMail;
using Hermes.Application.Services;

namespace Hermes.Web.Endpoints
{
    public class SendResetPasswordMail : Endpoint<SendResetPasswordMailRequest, SendResetPasswordMailResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;
        private IMailService _mailService;

        public SendResetPasswordMail(ICommandDispatcher dispatcher, ILogger logger, IMailService mailService)
        {
            _dispatcher = dispatcher;
            _logger = logger;
            _mailService = mailService;
        }

        public override void Configure()
        {
            Post("/passwordreset");
            AllowAnonymous();
        }

        public override async Task HandleAsync(SendResetPasswordMailRequest req, CancellationToken ct)
        {
            try
            {
                _mailService.SendPasswordResetEmail(req.Email, req.Token);
                await SendAsync(new SendResetPasswordMailResponse());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}