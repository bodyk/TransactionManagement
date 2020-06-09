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
    public class GetTransactionsByStatusHandler : IRequestHandler<GetTransactionsByStatusQuery, List<TransactionResult>>
    {
        private readonly ITransactionService transactionService;

        public GetTransactionsByStatusHandler(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public async Task<List<TransactionResult>> Handle(GetTransactionsByStatusQuery request, CancellationToken cancellationToken)
        {
            return await transactionService.GetAllByStatus(request.Status);
        }
    }
}
