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
    public class GetTransactionsByStatusHandler : IRequestHandler<GetTransactionsByStatusQuery, List<TransactionEntity>>
    {
        private readonly ITransactionService transactionService;

        public GetTransactionsByStatusHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public async Task<List<TransactionEntity>> Handle(GetTransactionsByStatusQuery request, CancellationToken cancellationToken)
        {
            return await transactionService.GetAllByStatus(request.Status);
        }
    }
}
