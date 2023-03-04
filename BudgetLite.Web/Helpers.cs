using BudgetLite.Data.Enums;
using MudBlazor;

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

        public static string BudgetIcon(Catagory budgetCatagory)
        {
            switch (budgetCatagory)
            {
                case Catagory.Home:
                    return Icons.Filled.House;
                case Catagory.Transportation:
                    return Icons.Filled.DirectionsCar;
                case Catagory.Food:
                    return Icons.Filled.Restaurant;
                case Catagory.Utilities:
                    return Icons.Filled.Bolt;
                case Catagory.Medical:
                    return Icons.Filled.LocalHospital;
                case Catagory.Debt:
                    return Icons.Filled.CreditCard;
                case Catagory.Entertainment:
                    return Icons.Filled.Movie;
                case Catagory.Savings:
                    return Icons.Filled.Savings;
                case Catagory.Shopping:
                    return Icons.Filled.ShoppingCart;
                case Catagory.Education:
                    return Icons.Filled.School;
                case Catagory.Charity:
                    return Icons.Filled.VolunteerActivism;
                case Catagory.ChildCare:
                    return Icons.Filled.ChildCare;
                default:
                    return Icons.Filled.Info;
            }
        }
    }
}
