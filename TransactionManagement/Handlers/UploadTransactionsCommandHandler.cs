using BusinessLogic.Services;
using ConversionLogic;
using ConversionLogic.FileServices.Abstraction;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TransactionManagement.Commands;
using TransactionManagement.FileServices.Abstraction;

namespace TransactionManagement.Handlers
{
    public class UploadTransactionsCommandHandler : IRequestHandler<UploadTransactionsCommand, int>
    {
        private readonly IXmlService xmlService;
        private readonly ICsvService csvService;
        private readonly ITransactionService transactionService;
        private readonly TransactionServiceFactory transactionServiceFactory;

        public UploadTransactionsCommandHandler(
            ITransactionService transactionService,
            IXmlService xmlService,
            ICsvService csvService,
            TransactionServiceFactory transactionServiceFactory)
        {
            this.transactionService = transactionService;
            this.xmlService = xmlService;
            this.csvService = csvService;
            this.transactionServiceFactory = transactionServiceFactory;
        }

        public async Task<int> Handle(UploadTransactionsCommand request, CancellationToken cancellationToken)
        {
            var file = request.FileViewModel.File;
            var conversionService = transactionServiceFactory.Create(file);
            var result = await conversionService.ToTransaction(file);

            return await transactionService.UpploadAsync(result);
        }
    }
}
