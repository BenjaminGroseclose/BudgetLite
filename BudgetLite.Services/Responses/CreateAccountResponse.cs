using BudgetLite.Data.Models;

namespace BudgetLite.Services.Responses
{
    public class CreateAccountResponse : IResponse
    {
        public CreateAccountResponse(bool succeeded, User createdUser, string errorMessage)
        {
            Succeeded = succeeded;
            CreatedUser = createdUser;
            ErrorMessage = errorMessage;
        }

        public bool Succeeded { get; set; }
        public User CreatedUser { get; set; }
        public string ErrorMessage { get; set; }
    }
}
