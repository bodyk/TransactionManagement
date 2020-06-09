using BusinessLogic.Services;
using Core.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TransactionManagement.Queries;

namespace TransactionManagement.Handlers
{
    public class GetTransactionsByDateRangeHandler : IRequestHandler<GetTransactionsByDateRangeQuery, List<TransactionResult>>
    {
        private readonly ITransactionService transactionService;

        public GetTransactionsByDateRangeHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public async Task<List<TransactionResult>> Handle(GetTransactionsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            return await transactionService.GetAllByDateRange(request.StartDate, request.EndDate);
        }
    }
}
