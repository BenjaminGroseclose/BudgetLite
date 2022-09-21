using BudgetLite.Services.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetLite.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateAccountRequest createAccountRequest);
    }
}
