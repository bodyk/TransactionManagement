using Core;
using MediatR;
using System.Collections.Generic;

namespace TransactionManagement.Queries
{
    public class GetTransactionsByStatusQuery : IRequest<List<TransactionResult>>
    {
        public GetTransactionsByStatusQuery(string status)
        {
            Status = status;
        }

        public string Status { get; private set; }
    }
}