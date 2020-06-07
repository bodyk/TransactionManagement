using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TransactionManagement.ViewModels.Status;

namespace TransactionManagement.ViewModels
{
    internal class CsvModel
    {
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public RegionInfo CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public CsvStatus Status { get; set; }
    }
}
