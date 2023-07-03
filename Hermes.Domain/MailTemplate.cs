using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Domain
{
    [Table("MailTemplates")]
    public record MailTemplate
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", TypeName = "nvarchar(200)"), Required]
        public string Name { get; set; }

        [Column("SenderEmail", TypeName = "nvarchar(200)"), Required]
        public string SenderEmail { get; set; }

        [Column("TargetEmail", TypeName = "nvarchar(200)"), Required]
        public string TargetEmail { get; set; }

        [Column("MailSubject", TypeName = "nvarchar(200)"), Required]
        public string MailSubject { get; set; }

        [Column("MailBody", TypeName = "nvarchar(200)"), Required]
        public string MailBody { get; set; }

        [Column("UserID", TypeName = "nvarchar(200)"), Required]
        public string UserID { get; set; }
    }
}
