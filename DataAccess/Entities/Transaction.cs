using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace DataAccess.Entities
{
    public class Transaction
    {
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
