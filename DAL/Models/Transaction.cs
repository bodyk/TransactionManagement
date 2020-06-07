using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace DAL.Models
{
    public class Transaction
    {
        [MaxLength(50)]
        [Required]
        public string Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public RegionInfo CurrencyCode { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
