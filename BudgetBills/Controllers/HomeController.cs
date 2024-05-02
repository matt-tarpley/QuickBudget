using BudgetBills.Models;
using BudgetBills.Models.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BudgetBills.Controllers
{
    public class HomeController : Controller
    {
        private BudgetBillsContext db;
        public HomeController(BudgetBillsContext context) => db = context;

        [HttpGet]
        public ViewResult Index(int[] filterArray)
        {
            IQueryable<Bill> query = db.Bills //creating a query that we can build on
                .Include(c => c.Category);

            if (filterArray != null && filterArray.Length > 0)
            {
                Filter billFilter = new Filter(filterArray);

                if (billFilter.HasNecessityLevel)
                {
                    string necessitylevel = billFilter.NecessityLevelId == 1 ? "Needs" : "Wants";

                    query = query.Where(b => b.Category.Description2 == necessitylevel);
                }
                if (billFilter.HasCategory)
                {
                    query = query.Where(b => b.CategoryId == billFilter.CategoryId);
                }
            }
            

            BillsViewModel viewModel = new BillsViewModel
            {
                Bills = query
                .OrderBy(b => b.BillId)
                .ToList(),

                Categories = db.Categories.ToList()
            };

            return View(viewModel);

        }

        //new bill
        [HttpPost]
        public RedirectToActionResult Index(BillsViewModel viewModel)
        {
            //gather new viewmodel data
            BillsViewModel updatedVM = new BillsViewModel
            {
                Bills = db.Bills
                .Include(c => c.Category) //include Category data foreach Bill's CategoryId
                .OrderBy(b => b.BillId)
                .ToList(),

                Categories = db.Categories.ToList()
            };

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All fields required.");
                return RedirectToAction("Index", updatedVM);
            }

            //if model looks good
            Bill newBill = viewModel.Bill;
            db.Bills.Add(newBill);
            db.SaveChanges();

            return RedirectToAction("Index", updatedVM);
        }

        [HttpPost]
        public RedirectToActionResult FilterBills(int[] FilterArray) { return RedirectToAction("Index", new { filterArray = FilterArray }); }
    }
}
