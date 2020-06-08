using System;

namespace Core
{
    public class TransactionDto
    {
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public Status Status { get; set; }
    }
}
