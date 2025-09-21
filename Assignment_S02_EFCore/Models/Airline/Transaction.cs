using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment_S02_EFCore.Models.Airline
{
    [Table("Transactions", Schema = "Airline")]
    internal class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required, MaxLength(50)]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(AirLine.RecordedTransactions))]
        public int TransactionsRecordedID { get; set; }
        public AirLine TransactionsRecorded { get; set; } = null!;
        

    }
}
