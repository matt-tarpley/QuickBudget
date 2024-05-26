namespace BudgetBills.Models.Helper
{
    public class Breakdown
    {
        //properties
        public double FiftyPercent { get; set; }
        public double ThirtyPercent { get; set; }
        public double TwentyPercent { get; set; }
        public double ActualSpentOnNeeds {  get; set; }
        public double ActualSpentOnWants { get; set; }
        public double ActualSpentOnSavingsDebt { get; set; }



        //methods
        public void SetIdealBreakdown(double incomeTotal)
        {
            FiftyPercent = incomeTotal * 0.50;
            ThirtyPercent = incomeTotal * 0.30;
            TwentyPercent = incomeTotal * 0.20;
        }

        public void SetActualBreakDown(Dictionary<Category, double> categoryTotals)
        {
            double needsTotal = 0, wantsTotal = 0, savingsDebtTotal = 0;

            //loop through dictionary set totals based on category
            foreach(var categoryTotal in categoryTotals)
            {
               if(categoryTotal.Key.Description2 == "Needs")
               {
                    needsTotal += categoryTotal.Value;
               } 
               else if(categoryTotal.Key.Description2 == "Wants")
               {
                    wantsTotal += categoryTotal.Value;
               }
               else
               {
                    savingsDebtTotal += categoryTotal.Value;
               }
            }

            //assign values
            ActualSpentOnNeeds = needsTotal;
            ActualSpentOnWants = wantsTotal;
            ActualSpentOnSavingsDebt = savingsDebtTotal;
        }
    }
}
