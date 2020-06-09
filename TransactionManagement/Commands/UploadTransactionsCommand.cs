using MediatR;
using TransactionManagement.Models;

namespace TransactionManagement.Commands
{
    public class UploadTransactionsCommand : IRequest<int>
    {
        public UploadTransactionsCommand(TransactionFileViewModel fileViewModel)
        {
            FileViewModel = fileViewModel;
        }

        public TransactionFileViewModel FileViewModel { get; private set; }
    }
}
