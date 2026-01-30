using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AkademiQPortfolio.Controllers
{
    public class ProjectnewController : Controller
    {
        private readonly portfolyodbContext _context;

        public ProjectnewController(portfolyodbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Include=Projeleri çekiyorum ama kategorisi de gelsin istiyorum.
            //Lambda (=>)-> Kısa fonksiyon
            //Lambda --> İlgili projenin kategorisini diğer tablodan çekmek için kullanıyorız

            //Garson Örneği
            //Sen:"Bana projeleri getir"
            //Garson:"Yanında ne olsun?"
            //Sen: "Kategorisi de olsun"

            var value = _context.ProjectsTables.Include(x => x.Category).ToList();


            var test = _context.ProjectsTables.ToList();

            return View(value);
        }
        // Bu metod, linkteki /5 rakamını (id) otomatik olarak yakalar
      
        //Dropdown --->2 unsuru var birincisi value ikincisi gözüken kısım
        //kullanıcı cybersecurity ekledğini düşünürken aynı zamanda arka tarafa biz cybersecurity'nin ID sini ekleyeceğiz

        //Select
        //SelectListItem
        [HttpGet]
        public IActionResult ProjectCreate()
        {
            //viewbag categories ----->her kategori için bir listeye veri ekleyecek bu listenin içerisinde bir gözüken kısım değeri ikinci olarak ise
            //Value değeri olacak bunları dropdownda kullanacağız

            //   ViewBag.Categories

            // liste[0]->Text = -- value= 1
            // liste[1] -> Text = Mobile value = 2

            ViewBag.Categories =_context.CategoryTables.Select(
                x =>new SelectListItem
                {
                    Text= x.CategoryName,
                    Value=x.CategoryId.ToString()

                }
                );
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProjectCreate(ProjectsTable projectsTable, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // 1. Resme benzersiz bir isim veriyoruz (Örn: 7af2...jpg)
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                // 2. Resmin kaydedileceği fiziksel yolu belirliyoruz (wwwroot/img/...)
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                // 3. Dosyayı klasöre kopyalıyoruz
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // 4. Veritabanına resmin klasördeki yolunu yazıyoruz
                projectsTable.Images = "/img/" + fileName;
            }

            _context.ProjectsTables.Add(projectsTable);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            // Veritabanından veriyi çekiyoruz
            var value = _context.ProjectsTables.Find(id);

            // GÜVENLİK: Eğer veri yoksa hata verme, Index'e gönder
            if (value == null)
            {
                return RedirectToAction("Index");
            }

            // Kategorileri doldurmayı UNUTMA (Hatanın sebebi bu olabilir)
            ViewBag.Categories = _context.CategoryTables.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(ProjectsTable p, IFormFile? imageFile) // async Task ekledik
        {
            // ... resim yükleme kodların ...

            _context.ProjectsTables.Update(p);

            // SaveChanges yerine SaveChangesAsync kullandık ve başına await koyduk
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteProject(int id)
        {
            var value = _context.ProjectsTables.Find(id);
            if (value != null)
            {
                _context.ProjectsTables.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
       

    