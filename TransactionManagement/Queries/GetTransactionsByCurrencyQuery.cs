using Core.Models;
using MediatR;
using System.Collections.Generic;

namespace TransactionManagement.Queries
{
    public class GetTransactionsByCurrencyQuery : IRequest<List<TransactionResult>>
    {
        public GetTransactionsByCurrencyQuery(string currency)
        {
            Currency = currency;
        }

        public string Currency { get; private set; }
    }
}