using DataAccess.Entities;
using DataAccess.Repositories;
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

        public Task UpploadAsync(IEnumerable<Transaction> transactions)
        {
            unitOfWork.TransactionRepository.Uppload(transactions);
            return unitOfWork.CommitAsync();
        }
    }
}
