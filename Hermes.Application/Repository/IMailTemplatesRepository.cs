using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Domain;

namespace Hermes.Application.Repository
{
    public interface IMailTemplatesRepository
    {
        Task<MailTemplate?> GetMailTemplateAsync(int id);

        Task<IEnumerable<MailTemplate>> GetMailTemplatesAsync(string? userID);

        Task<int> InsertMailTemplate(MailTemplate record);

        Task<MailTemplate> UpdateMailTemplate(MailTemplate record);

        void DeleteMailTemplate(int id);
    }
}
