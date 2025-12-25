using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
