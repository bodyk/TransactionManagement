using BusinessLogic.Services;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TransactionManagement.Queries;

namespace TransactionManagement.Handlers
{
    public class GetTransactionsByDateRangeHandler : IRequestHandler<GetTransactionsByDateRangeQuery, List<TransactionEntity>>
    {
        private readonly ITransactionService transactionService;

        public GetTransactionsByDateRangeHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public async Task<List<TransactionEntity>> Handle(GetTransactionsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            return await transactionService.GetAllByDateRange(request.StartDate, request.EndDate);
        }
    }
}
