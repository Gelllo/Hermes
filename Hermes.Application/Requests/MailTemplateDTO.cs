using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Requests
{
    public record MailTemplateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SenderEmail { get; set; }
        public string? TargetEmail { get; set; }
        public string? MailSubject { get; set; }
        public string? MailBody { get; set; }
        public string? UserID { get; set; }
    }
}
