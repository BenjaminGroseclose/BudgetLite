namespace BudgetLite.Web.Authentication
{
    public class UserSession
    {
        public UserSession(string username, string email, string givenName, int userID)
        {
            Username = username;
            Email = email;
            GivenName = givenName;
            UserID = userID;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public int UserID { get; set; }
    }
}
