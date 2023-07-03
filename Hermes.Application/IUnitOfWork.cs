using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hermes.Application.Repository;

namespace Hermes.Application
{
    public interface IUnitOfWork
    {
        IMailRequestsRepository MailRequestsRepository { get; }
        IMailTemplatesRepository MailTemplatesRepository { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
