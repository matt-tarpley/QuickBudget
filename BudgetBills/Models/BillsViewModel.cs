using BudgetBills.Models;
using System.Net;

namespace BudgetBills.Models
{
    public class BillsViewModel
    {
        public List<Bill> Bills {  get; set; } = new List<Bill>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public Bill Bill { get; set; } = new Bill();

    }
}
