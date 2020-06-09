using ConversionLogic.ViewModels.Status;
using System;

namespace ConversionLogic.ViewModels
{
    public class CsvViewModel
    {
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public CsvStatus Status { get; set; }
    }
}
