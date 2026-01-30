using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;


namespace AkademiQPortfolio.Controllers
{
    public class SkillnewController : Controller
    {
      
            private readonly portfolyodbContext _context;

        public SkillnewController(portfolyodbContext context) 
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skilltables.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skilltable skill)
        {
            _context.Skilltables.Add(skill);
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
        [HttpGet]
        //httpGet ile 5 numaralı id ye ait verileri getirdik bu şekilde sayfa ilk açıldığında neyi güncelleyeceğimizi göreceğiz.
        public IActionResult UpdateSkill(int id)
        {
            //ilgili veriyi veri tabanından buluyıruz dışarıdan aldığımız id değerine göre
            //güncelleme sayfası ilk açıldığında ilgili verilerin getirilmesi
            var SkillUpdate = _context.Skilltables.Find(id);

            if (SkillUpdate == null)
            {
                return RedirectToAction("SkillList");
            }

            return View(SkillUpdate); // ✅ DOĞRU
        }
        
        [HttpPost]
        //httpPost ile 5 numaralı idyi güncelleyeceğiz htmlde ilgili metin kutularında değişiklikleri yapıp güncelle butonuna basıldığında burası çalışacak
        public IActionResult UpdateSkill(Skilltable skill)
        {
            //skill=skillTable bu classta yer alan verilere göre veriniz var
            //gelen verilerde güncellemek istediğimiz veriyi değiştirdikten sonra bu verinin güncellenmesi

            //Bir verinin güncellenmesi için  * adım
            //1.adım veri tabanı bağlantısı tablo bağlantısı
            //2.adım güncellenecek veriyi al
            //3.adım güncellenecek veriyi güncelle
            //4.adım ctrl+s kaydet
            //5.adım bitiş

            _context.Skilltables.Update(skill); //1,2,3.adım
            _context.SaveChanges(); //4.adım



            return RedirectToAction("SkillList");
        }
        public IActionResult DeleteSkill(int id)

        {
            //1.adım veri tabanı bağlantısı tablo bağlantısı
            //2.adım ilgili veriyi bul neye göre ->idye bağlı
            //3.adım veriyi sil
            //4.adım değişiklikleri kaydet
            //5.adım bitiş

            var value = _context.Skilltables.Find(id); //1.ve 2. adım

            _context.Skilltables.Remove(value); //3.adım
            _context.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}
    

