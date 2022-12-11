using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLite.Data.Models
{
    public class User : IdentityUser<int>
    {
        public User() { }

        public User(string firstName, string lastName, string email, string username)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserName = username;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MonthlyIncome { get; set; }

        public decimal WeeklyIncome()
        {
            return this.MonthlyIncome / 4;
        }

        public decimal YearlyIncome()
        {
            return this.MonthlyIncome * 12;
        }

        public decimal QuarterlyIncome()
        {
            return this.MonthlyIncome * 3;
        }
    }
}
