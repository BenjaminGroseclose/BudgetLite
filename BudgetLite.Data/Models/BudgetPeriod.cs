using BudgetLite.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetLite.Data.Models
{
    public class BudgetPeriod : Entity
    {
        [Key]
        public int BudgetPeriodID { get; set; }
        public DurationType DurationType { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("Budget")]
        public int BudgetID { get; set; }
        public Budget Budget { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }

        public double AmountSpent { get { return this.Transactions.Select(x => x.Amount).Sum(); } }
    }
}
