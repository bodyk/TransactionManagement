using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ITransactionService
    {
        Task UpploadAsync(IEnumerable<TransactionEntity> transactions);
        Task<List<TransactionEntity>> GetAllByCurrency(string currency);
        Task<List<TransactionEntity>> GetAllByDateRange(DateTime startDate, DateTime endDate);
        Task<List<TransactionEntity>> GetAllByStatus(string status);
    }
}
