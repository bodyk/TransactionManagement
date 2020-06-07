using System;
using System.Collections.Generic;
using System.Text;
using TransactionManagement.ViewModels.Status;

namespace TransactionManagement.ViewModels
{
    internal class XmlModel
    {
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public XmlStatus Status { get; set; }
    }
}
