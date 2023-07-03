using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Application.Repository;
using Hermes.Domain;
using Hermes.Infrastracture.Database;
using Hermes.Infrastracture.Database.Repository;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Infrastructure.Repository
{
    public class MailRequestsRepository: GenericRepository<MailRequest>, IMailRequestsRepository, IDisposable
    {
        public MailRequestsRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<MailRequest?> GetMailRequestAsync(int id)
        {
            return await _dbContext.MailRequests.FindAsync(id);
        }

        public async Task<IEnumerable<MailRequest>> GetMailRequestsForPatientAsync(string? patientID)
        {
            return await _dbContext.MailRequests.AsQueryable().Where(x => x.PatientUsername == patientID && x.Status == StatusTypes.PENDING).ToListAsync();
        }

        public async Task<IEnumerable<MailRequest>> GetMailRequestsForMedicAsync(string? doctorID)
        {
            return await _dbContext.MailRequests.AsQueryable().Where(x => x.DoctorUsername == doctorID && x.Status == StatusTypes.SENT).ToListAsync();
        }

        public async Task<int> InsertMailRequest(MailRequest record)
        {
            await _dbContext.MailRequests.AddAsync(record);
            Save();
            return record.Id;
        }

        public async Task<MailRequest> UpdateMailRequest(MailRequest record)
        {
            _dbContext.Entry(record).State = EntityState.Modified;
            Save();
            return record;
        }

        public void DeleteMailRequest(int id)
        {
            MailRequest req = _dbContext.MailRequests.Find(id);
            _dbContext.MailRequests.Remove(req);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
