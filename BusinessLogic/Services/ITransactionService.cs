using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ITransactionService
    {
        Task UpploadAsync(IEnumerable<Transaction> transactions);
    }
}
