using Core;
using DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace TransactionManagement.Queries
{
    public class GetTransactionsByDateRangeQuery : IRequest<List<TransactionResult>>
    {
        public GetTransactionsByDateRangeQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }
}