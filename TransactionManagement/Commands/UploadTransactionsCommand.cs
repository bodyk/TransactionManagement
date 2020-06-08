using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionManagement.Models;
using TransactionManagement.Responses;

namespace TransactionManagement.Commands
{
    public class UploadTransactionsCommand : IRequest<UploadTransactionsResponse>
    {
        public UploadTransactionsCommand(TransactionFileViewModel fileViewModel)
        {
            FileViewModel = fileViewModel;
        }

        public TransactionFileViewModel FileViewModel { get; private set; }
    }
}
