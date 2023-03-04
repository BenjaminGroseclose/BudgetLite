using BudgetLite.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetLite.Data.Models
{
    public class Transaction : Entity
    {
        [Key]
        public int TransactionID { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        public int BudgetPeriodID { get; set; }

        [ForeignKey(nameof(BudgetPeriodID))]
        public BudgetPeriod BudgetPeriod { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Catagory Catagory { get; set; }
        public string? Notes { get; set; }
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
