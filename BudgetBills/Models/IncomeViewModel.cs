namespace BudgetBills.Models
{
    public class IncomeViewModel
    {
        public List<IncomeSource> IncomeSources { get; set; } = new List<IncomeSource>();
        public IncomeSource IncomeSource { get; set; } = new IncomeSource();
    }
}
