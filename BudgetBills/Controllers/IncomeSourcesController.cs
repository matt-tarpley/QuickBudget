using Microsoft.AspNetCore.Mvc;

namespace BudgetBills.Controllers
{
    public class IncomeSourcesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
