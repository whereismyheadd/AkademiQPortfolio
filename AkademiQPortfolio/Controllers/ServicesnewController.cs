using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;


namespace AkademiQPortfolio.Controllers
{
    public class ServicesnewController : Controller
    {
        private readonly portfolyodbContext _context;

        //DI DEPENDENCY INJECTION Mediumdan bununla ilgili makale oku

        //asp.net DI -->Farklı diillerde de bakabilirsiniz.
        public ServicesnewController(portfolyodbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Services.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateServices()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateServices(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateServices(int id) 
        { 
            var value = _context.Services.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateServices(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteServices(int id)

        {
            //1.adım veri tabanı bağlantısı tablo bağlantısı
            //2.adım ilgili veriyi bul neye göre ->idye bağlı
            //3.adım veriyi sil
            //4.adım değişiklikleri kaydet
            //5.adım bitiş

            var value = _context.Services.Find(id); //1.ve 2. adım

            _context.Services.Remove(value); //3.adım
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
