using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<List<TransactionEntity>> GetAllByCurrency(string currency)
        {
            return unitOfWork.TransactionRepository.GetAllByCurrency(currency);
        }

        public Task<List<TransactionEntity>> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            return unitOfWork.TransactionRepository.GetAllByDateRange(startDate, endDate);
        }

        public Task<List<TransactionEntity>> GetAllByStatus(string status)
        {
            Status st = (Status)Enum.Parse(typeof(Status), status);
            return unitOfWork.TransactionRepository.GetAllByStatus(st);
        }

        public Task UpploadAsync(IEnumerable<TransactionEntity> transactions)
        {
            unitOfWork.TransactionRepository.Uppload(transactions);
            return unitOfWork.CommitAsync();
        }
    }
}
