using Core;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ITransactionService
    {
        Task UpploadAsync(List<TransactionDto> transactions);
        Task<List<TransactionResult>> GetAllByCurrency(string currency);
        Task<List<TransactionResult>> GetAllByDateRange(DateTime startDate, DateTime endDate);
        Task<List<TransactionResult>> GetAllByStatus(string status);
    }
}
