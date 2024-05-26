namespace BudgetBills.Models.Helper
{
    public class IncomeVMInitializer: IInitViewModel<IncomeViewModel>
    {
        public IncomeViewModel BuildViewModel(BudgetBillsContext db)
        {
            IncomeViewModel viewModel = new IncomeViewModel
            {
                IncomeSources = db.IncomeSources
                    .OrderBy(i => i.IncomeId)
                    .ToList()
            };

            return viewModel;
        }
    }
}
