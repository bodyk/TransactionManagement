using Core;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ITransactionRepository
    {
        Task Uppload(IEnumerable<TransactionEntity> transactions);
        Task<List<TransactionEntity>> GetAllByCurrency(string currency);
        Task<List<TransactionEntity>> GetAllByDateRange(DateTime startDate, DateTime endDate);
        Task<List<TransactionEntity>> GetAllByStatus(Status status);
    }
}
