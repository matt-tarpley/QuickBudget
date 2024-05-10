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


        [HttpGet] //initial entry and filter
        public ViewResult Index(int[] filterArray)
        {
            IQueryable<Bill> query = db.Bills //creating a query that we can build on
                .Include(c => c.Category);

            //filter logic
            if (filterArray != null && filterArray.Length > 0)
            {
                Filter billFilter = new Filter(filterArray);

                if (billFilter.HasNecessityLevel)
                {
                    string necessitylevel = billFilter.NecessityLevelId == 1 ? "Needs" : "Wants"; //map numerical value to string value 

                    query = query.Where(b => b.Category.Description2 == necessitylevel);
                }
                if (billFilter.HasCategory)
                {
                    query = query.Where(b => b.CategoryId == billFilter.CategoryId);
                }
            }
            
            //initialize helper and create viewmodel
            BillsVMInitializer init = new BillsVMInitializer();
            BillsViewModel viewModel = init.BuildFilteredViewModel(db, query);

            return View(viewModel);

        }

        [HttpPost] //add bill
        public RedirectToActionResult Index(BillsViewModel viewModel)
        {

            //initialize helper and create new viewmodel
            BillsVMInitializer init = new BillsVMInitializer();
            BillsViewModel updatedVM = init.BuildViewModel(db);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All fields required.");
                return RedirectToAction("Index", updatedVM);
            }

            //if model looks good
            Bill newBill = viewModel.Bill; //create new bill with passed in vm
            db.Bills.Add(newBill);
            db.SaveChanges();

            return RedirectToAction("Index", updatedVM);
        }

        [HttpPost] //PRG pattern for filter
        public RedirectToActionResult FilterBills(int[] FilterArray) { return RedirectToAction("Index", new { filterArray = FilterArray }); }

        [HttpGet] //edit bill view
        public IActionResult Edit(int id) {

            if(id != 0) //if id is passed in
            {
                //create initializer and build VM
                BillsVMInitializer init = new BillsVMInitializer();
                BillsViewModel viewModel = init.BuildSingleBillViewModel(db, id);

                return View(viewModel);

            }
            else //if attempting to access through url **sort of uneccesary but just incase**
            {
                return RedirectToAction("Index");
            }
        
        }

        [HttpPost] //delete or update bill
        public IActionResult Edit(string btnType, BillsViewModel viewModel) 
        {
            if (btnType != null)
                RedirectToAction("Index"); //relocate to index if no btnType passed in

            if(ModelState.IsValid)
            {
                switch (btnType)
                {
                    case "delete":
                        Bill bill = db.Bills.Find(viewModel.Bill.BillId);
                        db.Bills.Remove(bill);
                        break;

                    case "update":
                        db.Update(viewModel.Bill);
                        break;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            else
            {
                ModelState.AddModelError("", "All fields required.");
                return View("Edit");
            }
        }
    }
}
