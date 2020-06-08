using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ITransactionRepository
    {
        Task Uppload(IEnumerable<TransactionEntity> transactions);
        IAsyncEnumerable<TransactionEntity> GetAll();
    }
}
