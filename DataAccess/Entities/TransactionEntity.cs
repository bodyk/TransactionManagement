using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table("Transactions")]
    public class TransactionEntity
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
