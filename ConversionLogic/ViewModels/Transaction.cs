using ConversionLogic.ViewModels.Status;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConversionLogic.ViewModels
{
    public class Transaction
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public DateTime TransactionDate { get; set; }
        public XmlStatus Status { get; set; }
    }
}
