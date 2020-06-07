using DAL.Models.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    internal class XmlModel
    {
        public string TransactionIdentifier { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public XmlStatus Status { get; set; }
    }
}
