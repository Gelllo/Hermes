using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Domain
{
    [Table("MailRequests")]
    public record MailRequest
    {
        [Key]
        public int Id { get; set; }

        [Column("DoctorUsername", TypeName = "nvarchar(200)"), Required]
        public string DoctorUsername { get; set; }

        [Column("PatientUsername", TypeName = "nvarchar(200)"), Required]
        public string PatientUsername { get; set; }

        [Column("DateRequested", TypeName = "DateTime"), Required]
        public DateTime DateRequested { get; set; }

        [Column("Status", TypeName = "nvarchar(200)"),Required]
        public string Status { get; set; }

        [Column("ReportRequested", TypeName = "nvarchar(200)"), Required]
        public string ReportRequested { get; set; }
    }

    public static class StatusTypes
    {
        public static readonly string[] types = { "PENDING", "SENT"};

        public static readonly string PENDING = "PENDING";

        public static readonly string SENT = "SENT";
    }

    public static class ReportRequestedTypes
    {
        public static readonly string[] types = { "FOOD", "GLUCOSE" };

        public static readonly string FOOD = "FOOD";

        public static readonly string GLUCOSE = "GLUCOSE";
    }
}
