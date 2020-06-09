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
