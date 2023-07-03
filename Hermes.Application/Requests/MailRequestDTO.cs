using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Requests
{
    public record MailRequestDTO
    {
        public int Id { get; set; }
        public string? DoctorUsername { get; set; }
        public string? PatientUsername { get; set; }
        public string? DateRequested { get; set; }
        public string? Status { get; set; }
        public string? ReportRequested { get; set; }
    }
}
