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
    public class MailTemplatesRepository: GenericRepository<MailTemplate>, IMailTemplatesRepository, IDisposable
    {
        public MailTemplatesRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public async Task<MailTemplate?> GetMailTemplateAsync(int id)
        {
            return await _dbContext.MailTemplates.FindAsync(id);
        }

        public async Task<IEnumerable<MailTemplate>> GetMailTemplatesAsync(string? userID)
        {
            return await _dbContext.MailTemplates.AsQueryable().Where(x => x.UserID == userID).ToListAsync();
        }

        public async Task<int> InsertMailTemplate(MailTemplate record)
        {
            await _dbContext.MailTemplates.AddAsync(record);
            Save();
            return record.Id;
        }

        public async Task<MailTemplate> UpdateMailTemplate(MailTemplate record)
        {
            _dbContext.MailTemplates.Entry(record).State = EntityState.Modified;
            Save();
            return record;
        }

        public void DeleteMailTemplate(int id)
        {
            MailTemplate template = _dbContext.MailTemplates.Find(id);
            _dbContext.MailTemplates.Remove(template);
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
