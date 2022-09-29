using BudgetLite.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetLite.Data.Models
{
    public class Transaction : Entity
    {
        public int TransactionID { get; set; }

        [ForeignKey("BudgetPeriod")]
        public int BudgetPeriodID { get; set; }
        public BudgetPeriod BudgetPeriod { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Catagory Catagory { get; set; }
    }
}
