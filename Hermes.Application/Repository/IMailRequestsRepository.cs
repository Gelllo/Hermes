using Hermes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hermes.Application.Repository
{
    public interface IMailRequestsRepository
    {
        Task<MailRequest?> GetMailRequestAsync(int id);

        Task<IEnumerable<MailRequest>> GetMailRequestsForPatientAsync(string? patientID);

        Task<IEnumerable<MailRequest>> GetMailRequestsForMedicAsync(string? medicID);

        Task<int> InsertMailRequest(MailRequest record);

        Task<MailRequest> UpdateMailRequest(MailRequest record);

        void DeleteMailRequest(int id);
    }
}
