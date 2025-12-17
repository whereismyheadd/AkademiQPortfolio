using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
//wwwroot/css/site.css

//wwwroo/css/site.css

//Layout hiçbir zaman tek başına çalışmaz neden -> renderBody()->bizim sonradan oluşturacağımız içerik sayfalarını buranın içine atıyor

//yetenekler sayfasındaki  her şey renderbodynin içinde olacak