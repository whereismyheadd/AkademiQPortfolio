using Microsoft.AspNetCore.Mvc;
//Kütüphaneleri çağırıyor

namespace AkademiQPortfolio.Controllers
{
    public class DefaultController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
