using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        ITransactionRepository TransactionRepository { get; }

        Task CommitAsync();
    }
}
