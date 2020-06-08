using ConversionLogic.ViewModels.Status;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConversionLogic.ViewModels
{
    [XmlType(TypeName = "Transaction")]
    public class TransactionViewModel : IBaseTransactionViewModel
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public DateTime TransactionDate { get; set; }
        public XmlStatus Status { get; set; }
    }
}
