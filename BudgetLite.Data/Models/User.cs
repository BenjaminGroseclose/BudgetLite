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
        public User(string firstName, string lastName, string email, string username)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserName = username;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
