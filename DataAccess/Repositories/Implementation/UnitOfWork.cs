using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public ITransactionRepository TransactionRepository { get; }

        public UnitOfWork(ITransactionRepository transactionRepository)
        {
            TransactionRepository = transactionRepository;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
