using Core;
using DataAccess.DataContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext databaseContext;

        public TransactionRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IAsyncEnumerable<TransactionEntity> GetAll()
        {
            return databaseContext.Transactions.AsAsyncEnumerable();
        }

        public Task<List<TransactionEntity>> GetAllByCurrency(string currency)
        {
            return databaseContext.Transactions
                .Where(t => t.CurrencyCode == currency)
                .ToListAsync();
        }

        public Task<List<TransactionEntity>> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            return databaseContext.Transactions
                .Where(t => t.TransactionDate > startDate && t.TransactionDate < endDate)
                .ToListAsync();
        }

        public Task<List<TransactionEntity>> GetAllByStatus(Status status)
        {
            return databaseContext.Transactions
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public Task Uppload(IEnumerable<TransactionEntity> transactions)
        {
            databaseContext.Transactions.AddRange(transactions);
            return databaseContext.SaveChangesAsync();
        }
    }
}
