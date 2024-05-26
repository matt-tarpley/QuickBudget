using BudgetBills.Models.Helper;

namespace BudgetBills.Models
{
    public class SummaryViewModel
    {
        public SummaryViewModel() 
        {
            BreakDown = new Breakdown();
        }

        //lists
        public List<Bill> Bills { get; set; }   
        public List<IncomeSource> IncomeSources { get; set; }

        //totals
        public double IncomeTotal { get; set; }
        public double  BillsTotal { get; set;}
        public Dictionary<Category, double> CategoryTotals { get; set;}

        //check allocations and remaining balances
        public Dictionary<IncomeSource, List<Bill>> CheckAllocations { get; set; }
        public Dictionary<string, double> RemainingCheckBalances { get; set; }



        //object to hold 50/30/20 breakdown info
        public Breakdown BreakDown { get; set; }

        //readonly
        public double RemaingBalance => IncomeTotal - BillsTotal;
    }
}
