using BusinessLogic.Services;
using Core;
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
    public class GetTransactionsByDateRangeHandler : IRequestHandler<GetTransactionsByDateRangeQuery, List<TransactionDto>>
    {
        private readonly ITransactionService transactionService;

        public GetTransactionsByDateRangeHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public async Task<List<TransactionDto>> Handle(GetTransactionsByDateRangeQuery request, CancellationToken cancellationToken)
        {
            return await transactionService.GetAllByDateRange(request.StartDate, request.EndDate);
        }
    }
}
