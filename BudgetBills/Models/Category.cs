namespace BudgetBills.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Description1 { get; set; } 
        public string Description2 { get; set; }

        //navigation property
        public ICollection<Bill> Bills { get; set; }

    }
}
