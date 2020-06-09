using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        ITransactionRepository TransactionRepository { get; }

        Task<int> CommitAsync();
    }
}
