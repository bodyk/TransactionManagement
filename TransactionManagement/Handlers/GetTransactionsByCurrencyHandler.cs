using BusinessLogic.Services;
using Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransactionManagement.Queries;

namespace TransactionManagement.Handlers
{
    public class GetTransactionsByCurrencyHandler : IRequestHandler<GetTransactionsByCurrencyQuery, List<TransactionResult>>
    {
        private readonly ITransactionService transactionService;

        public GetTransactionsByCurrencyHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public async Task<List<TransactionResult>> Handle(GetTransactionsByCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await transactionService.GetAllByCurrency(request.Currency);
        }
    }
}
