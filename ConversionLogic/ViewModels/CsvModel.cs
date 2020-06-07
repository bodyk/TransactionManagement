using ConversionLogic.ViewModels.Status;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConversionLogic.ViewModels
{
    public class CsvModel
    {
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public RegionInfo CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public CsvStatus Status { get; set; }
    }
}
