using FastEndpoints;
using Hermes.Application.Requests.MailTemplate;
using Hermes.Application.Responses.MailTemplate;
using Hermes.Application;
using Hermes.Application.Services;
using Hermes.Application.Requests.SendMail;
using Hermes.Application.Responses.SendMail;

namespace Hermes.Web.Endpoints
{
    public class SendMail : Endpoint<SendMailRequest, SendMailResponse>
    {
        private ICommandDispatcher _dispatcher;
        private ILogger _logger;
        private IMailService _mailService;

        public SendMail(ICommandDispatcher dispatcher, ILogger logger, IMailService mailService)
        {
            _dispatcher = dispatcher;
            _logger = logger;
            _mailService = mailService;
        }

        public override void Configure()
        {
            Post("/sendmail/{UserName}");
            Roles("USER","MEDIC");
            AllowFileUploads();
        }

        public override async Task HandleAsync(SendMailRequest req, CancellationToken ct)
        {
            try
            {
                req.UserName = Route<string>("UserName");
                _mailService.SendReportEmail(req.TargetMail, req.MailSubject,
                    req.MailBody, req.UserName, req.FormFiles);
                await SendAsync(new SendMailResponse());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}
