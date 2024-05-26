using Microsoft.AspNetCore.Mvc;
using BudgetBills.Models;
using BudgetBills.Models.Helper;

namespace BudgetBills.Controllers
{
    public class SummaryController : Controller
    {
        private BudgetBillsContext db;
        public SummaryController(BudgetBillsContext context) => db = context;


        [HttpGet]
        public ViewResult Index()
        {
            SummaryVMInitializer init = new SummaryVMInitializer();
            SummaryViewModel viewModel = init.BuildViewModel(db);

            //initialize check allocations and remaining balances
            viewModel.CheckAllocations = new Dictionary<IncomeSource, List<Bill>>();
            viewModel.RemainingCheckBalances = new Dictionary<string, double>();
            
            //initializes a key for each check in income sources and a corresponding empty list of bills 
            foreach (IncomeSource check in viewModel.IncomeSources)
            {
                viewModel.CheckAllocations[check] = new List<Bill>();
            }

            //for every check loop through all the bills 
            foreach(IncomeSource check in viewModel.IncomeSources)
            {
                double remainingBalance = check.Amount; 

                foreach(Bill bill in viewModel.Bills)
                {
                    if(check.RecieveDate < bill.DueDate && !bill.IsPaid)
                    {
                        //add bill to list for that specific check and mark as paid 
                        viewModel.CheckAllocations[check].Add(bill);
                        remainingBalance -= bill.Amount; //calc remaining balance for that check
                        bill.IsPaid = true;
                    }
                }

                //add check name and remaining balance after allocated bills
                viewModel.RemainingCheckBalances.Add(check.Description, remainingBalance); 
            }
            return View(viewModel);
        }
    }
}
