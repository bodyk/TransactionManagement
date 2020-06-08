using Core;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;

namespace TransactionManagement.Queries
{
    public class GetTransactionsByCurrencyQuery : IRequest<List<TransactionDto>>
    {
        public GetTransactionsByCurrencyQuery(string currency)
        {
            Currency = currency;
        }

        public string Currency { get; private set; }
    }
}