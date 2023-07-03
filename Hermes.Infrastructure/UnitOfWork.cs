using Hermes.Infrastracture.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Application;
using Hermes.Application.Repository;
using Hermes.Infrastructure.Repository;

namespace Hermes.Infrastracture.Database
{
    public class UnitOfWork :IUnitOfWork, IDisposable
    {
        private readonly DataContext _dbContext;
        private IMailRequestsRepository _mailRequestsRepository;
        private IMailTemplatesRepository _mailTemplatesRepository;


        public UnitOfWork(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMailRequestsRepository MailRequestsRepository
        {
            get
            {
                return _mailRequestsRepository = _mailRequestsRepository ?? new MailRequestsRepository(_dbContext);
            }
        }

        public IMailTemplatesRepository MailTemplatesRepository
        {
            get
            {
                return _mailTemplatesRepository = _mailTemplatesRepository ?? new MailTemplatesRepository(_dbContext);
            }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true); GC.SuppressFinalize(this);
        }
    }
}
