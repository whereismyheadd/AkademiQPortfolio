using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        //verileri burada listeleyeceğiz
        public IActionResult Index()
        {
            return View();
        }
        //Create metotu için get fonksiyonu
        public IActionResult CreatedExperience()
        {
            return View();
        }
        //güncelleme için get fonksiyonu

        //burası get fonksiyonu update için
        public IActionResult UpdateExperience()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult DeleteExperience() 
        { 
            //burası değişicek butona basınca direkt silecek
            return View();
        }

    }
}
