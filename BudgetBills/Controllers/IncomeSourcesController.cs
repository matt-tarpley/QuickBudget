using Microsoft.AspNetCore.Mvc;
using BudgetBills.Models;
using BudgetBills.Models.Helper;

namespace BudgetBills.Controllers
{
    public class IncomeSourcesController : Controller
    {
        private BudgetBillsContext db;
        public IncomeSourcesController(BudgetBillsContext context) => db = context;

        [HttpGet]
        public ViewResult Index()
        {
            IncomeVMInitializer init = new IncomeVMInitializer();
            IncomeViewModel viewModel = init.BuildViewModel(db);

            return View(viewModel);
        }

        [HttpPost]
        public RedirectToActionResult Index(IncomeViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All fields required");
                return RedirectToAction("Index");
            }

            //if model state looks good
            IncomeSource incomeSource = viewModel.IncomeSource;
            db.IncomeSources.Add(incomeSource);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
