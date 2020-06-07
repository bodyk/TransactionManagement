﻿using DataAccess.DataContext;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
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

        public IAsyncEnumerable<Transaction> GetAll()
        {
            return databaseContext.Transactions.AsAsyncEnumerable();
        }

        public Task Uppload(IEnumerable<Transaction> transactions)
        {
            databaseContext.Transactions.AddRange(transactions);
            return databaseContext.SaveChangesAsync();
        }
    }
}