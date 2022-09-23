namespace BudgetLite.Services.Responses
{
    internal interface IResponse
    {
        bool Succeeded { get; set; }
        string ErrorMessage { get; set; }
    }
}
