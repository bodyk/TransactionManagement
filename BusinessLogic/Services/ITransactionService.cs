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
        Task<List<TransactionDto>> GetAllByCurrency(string currency);
        Task<List<TransactionDto>> GetAllByDateRange(DateTime startDate, DateTime endDate);
        Task<List<TransactionDto>> GetAllByStatus(string status);
    }
}
