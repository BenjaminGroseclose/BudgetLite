namespace BudgetLite.Web
{
    public static class Helpers
    {
        /// <summary>
        /// Inclusive between for dates
        /// </summary>
        /// <param name="input">The date to check if is between</param>
        /// <param name="date1">The start date</param>
        /// <param name="date2">The end date</param>
        /// <returns></returns>
        public static bool Between(this DateTime input, DateTime date1, DateTime date2)
        {
            return (input >= date1 && input <= date2);
        }
    }
}
