namespace BudgetBills.Models.Helper
{
    public class SummaryVMInitializer: IInitViewModel<SummaryViewModel>
    {
        public SummaryViewModel BuildViewModel(BudgetBillsContext db)
        {
            List<Bill> bills = db.Bills.ToList();
            List<IncomeSource> incomeSources = db.IncomeSources.ToList();
            List<Category> categories = db.Categories.ToList();

            //calculate bill and income source totals
            double billsTotal = 0, incomeTotal = 0;
            foreach (Bill bill in bills)
            {
                billsTotal += bill.Amount;
            }
            foreach(IncomeSource incomeSource in incomeSources)
            {
                incomeTotal += incomeSource.Amount;
            }

            //calculate total foreach category
            Dictionary<Category, double> categoryTotals = new Dictionary<Category, double>();
            foreach (Category category in categories)
            {
                double categoryTotal = 0;
                foreach (Bill bill in bills)
                {
                    if (bill.CategoryId == category.CategoryId)
                    {
                        categoryTotal += bill.Amount;
                    }
                }
                categoryTotals.Add(category, categoryTotal);
            }

            //populate VM
            SummaryViewModel viewModel = new SummaryViewModel
            {
                Bills = bills,
                IncomeSources = incomeSources,
                IncomeTotal = incomeTotal,
                BillsTotal = billsTotal,
                CategoryTotals = categoryTotals
            };

            //set 50/30/20 breakdowns in view model
            viewModel.BreakDown.SetIdealBreakdown(viewModel.IncomeTotal);
            viewModel.BreakDown.SetActualBreakDown(categoryTotals);

            return viewModel;
        }
    }
}
