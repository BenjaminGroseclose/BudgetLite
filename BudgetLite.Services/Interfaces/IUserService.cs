using BudgetLite.Services.Requests;
using BudgetLite.Services.Responses;

namespace BudgetLite.Services.Interfaces
{
    public interface IUserService
    {
        Task<CreateAccountResponse> CreateUser(CreateAccountRequest createAccountRequest);
    }
}
