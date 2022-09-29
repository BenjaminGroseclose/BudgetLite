using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLite.Data.Models
{
    public class BudgetPeriod : Entity
    {
        [Key]
        public int BudgetPeriodID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double AmountSpent { get; set; }

        [ForeignKey("Budget")]
        public int BudgetID { get; set; }
        public Budget Budget { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
