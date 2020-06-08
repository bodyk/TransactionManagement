using BusinessLogic.Services;
using ConversionLogic.FileServices.Abstraction;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionManagement.Commands;
using TransactionManagement.FileServices.Abstraction;
using TransactionManagement.Responses;

namespace TransactionManagement.Handlers
{
    public class UploadTransactionsCommandHandler : IRequestHandler<UploadTransactionsCommand, UploadTransactionsResponse>
    {
        private readonly IXmlService xmlService;
        private readonly ICsvService csvService;
        private readonly ITransactionService transactionService;

        public UploadTransactionsCommandHandler(
            ITransactionService transactionService,
            IXmlService xmlService,
            ICsvService csvService)
        {
            this.transactionService = transactionService;
            this.xmlService = xmlService;
            this.csvService = csvService;
        }

        public async Task<UploadTransactionsResponse> Handle(UploadTransactionsCommand request, CancellationToken cancellationToken)
        {
            List<TransactionEntity> entities = new List<TransactionEntity>();
            if (request.FileViewModel.File.FileName.EndsWith("csv"))
            {
                var res = await csvService.ToTransaction(request.FileViewModel.File);
                foreach (var item in res)
                {
                    var tr = new TransactionEntity
                    {
                        Amount = item.Amount,
                        CurrencyCode = item.CurrencyCode.ToString(),
                        Id = item.TransactionIdentificator,
                        Status = (Status)item.Status,
                        TransactionDate = item.TransactionDate
                    };
                    entities.Add(tr);
                }
            }
            else if (request.FileViewModel.File.FileName.EndsWith("xml"))
            {
                var res = await xmlService.ToTransaction(request.FileViewModel.File);
                foreach (var item in res)
                {
                    var tr = new TransactionEntity
                    {
                        Amount = item.PaymentDetails.Amount,
                        CurrencyCode = item.PaymentDetails.CurrencyCode,
                        Id = item.Id,
                        Status = (Status)item.Status,
                        TransactionDate = item.TransactionDate
                    };
                    entities.Add(tr);
                }
            }
            await transactionService.UpploadAsync(entities);

            return new UploadTransactionsResponse();
        }
    }
}
