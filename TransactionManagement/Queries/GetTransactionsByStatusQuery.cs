using Core;
using DataAccess.Entities;
using MediatR;
using System.Collections.Generic;

namespace TransactionManagement.Queries
{
    public class GetTransactionsByStatusQuery : IRequest<List<TransactionDto>>
    {
        public GetTransactionsByStatusQuery(string status)
        {
            Status = status;
        }

        public string Status { get; private set; }
    }
}