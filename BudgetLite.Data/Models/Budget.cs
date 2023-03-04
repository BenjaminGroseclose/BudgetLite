using BudgetLite.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetLite.Data.Models
{
    public class Budget : Entity
    {
        [Key]
        public int BudgetID { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        public Catagory Catagory { get; set; }

        public double Amount { get; set; }

        public int? ParentBudgetID { get; set; }

        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        public DurationType DurationType { get; set; }

        public IEnumerable<BudgetPeriod> BudgetPeriods { get; set; }
    }
}
