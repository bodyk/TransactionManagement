using DataAccess.DataContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext databaseContext;

        public ITransactionRepository TransactionRepository { get; }

        public UnitOfWork(DatabaseContext databaseContext, ITransactionRepository transactionRepository)
        {
            this.databaseContext = databaseContext;
            TransactionRepository = transactionRepository;
        }

        public Task CommitAsync()
        {
            return databaseContext.SaveChangesAsync();
        }
    }
}
