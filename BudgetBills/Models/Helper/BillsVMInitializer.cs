using Microsoft.EntityFrameworkCore;

namespace BudgetBills.Models.Helper
{
    public class BillsVMInitializer: IInitViewModel<BillsViewModel>
    {
        //implementation method from Interface
        public BillsViewModel BuildViewModel(BudgetBillsContext db)
        {
            //gather new viewmodel data
            BillsViewModel viewModel = new BillsViewModel
            {
                Bills = db.Bills
                .Include(c => c.Category) //include Category data foreach Bill's CategoryId
                .OrderBy(b => b.BillId)
                .ToList(),

                Categories = db.Categories.ToList()
            };

            return viewModel;
        }

        //specific to Bills for now, build vm using custom query
        public BillsViewModel BuildFilteredViewModel(BudgetBillsContext db, IQueryable<Bill> query)
        {
            //create new viewmodel
            BillsViewModel viewModel = new BillsViewModel
            {
                Bills = query
                .OrderBy(b => b.BillId)
                .ToList(),

                Categories = db.Categories.ToList()
            };

            return viewModel;
        }

        //return single bill
        public BillsViewModel BuildSingleBillViewModel(BudgetBillsContext db, int id)
        {
            BillsViewModel viewModel = new BillsViewModel
            {
                Bill = db.Bills.Find(id),
                Categories = db.Categories.ToList()
            };

            return viewModel;
        }

    }
}
