using DataAccess.DataContext;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext databaseContext;

        public ITransactionRepository TransactionRepository { get; }

        public UnitOfWork(DatabaseContext databaseContext, ITransactionRepository transactionRepository)
        {
            this.databaseContext = databaseContext;
            TransactionRepository = transactionRepository;
        }

        public Task<int> CommitAsync()
        {
            return databaseContext.SaveChangesAsync();
        }
    }
}
