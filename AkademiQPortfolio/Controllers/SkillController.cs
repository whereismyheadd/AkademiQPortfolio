using AkademiQPortfolio.Data;
using Microsoft.AspNetCore.Mvc;
using portfolyoDbContext;

namespace AkademiQPortfolio.Controllers
{
    public class SkillController : Controller
    {

        private readonly portfolyodbContext _portfolyodbContext;

        public SkillController(portfolyodbContext portfolyodbContext)
        {
            _portfolyodbContext = portfolyodbContext;
        }

        public IActionResult Index()
        {
            //tüm yetenekleri listele  _portfolyodbContext
            //Bizim veri tabanında 10 tane verimiz var bu 10 veriyi liste şeklinde getiriyor

           
            var SkillList = _portfolyodbContext.Skilltables.ToList();

            return View(SkillList);
        }

        [HttpGet]
        //httpGet ile 5 numaralı id ye ait verileri getirdik bu şekilde sayfa ilk açıldığında neyi güncelleyeceğimizi göreceğiz.
        public IActionResult UpdateSkill(int id)
        {
            //ilgili veriyi veri tabanından buluyıruz dışarıdan aldığımız id değerine göre
            //güncelleme sayfası ilk açıldığında ilgili verilerin getirilmesi
            var SkillUpdate = _portfolyodbContext.Skilltables.Find(id);

            return View(SkillUpdate);
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

            _portfolyodbContext.Skilltables.Update(skill); //1,2,3.adım
           _portfolyodbContext.SaveChanges(); //4.adım



            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult CreateSkill()
        {
            return View();
         }
        [HttpPost]
        public IActionResult CreateSkill(Skilltable skill)
        { 
            _portfolyodbContext.Skilltables.Add(skill);
            _portfolyodbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //araştırılacak burada neden httpget kullanmadık
        //bu işlem veri sildiği için httpGet ile yapılması önerilmez
        //güvenli kullanım için httppost tercih edilmelidir
        public IActionResult DeleteSkill(int id)

        {
            //1.adım veri tabanı bağlantısı tablo bağlantısı
            //2.adım ilgili veriyi bul neye göre ->idye bağlı
            //3.adım veriyi sil
            //4.adım değişiklikleri kaydet
            //5.adım bitiş

            var value = _portfolyodbContext.Skilltables.Find(id); //1.ve 2. adım

            _portfolyodbContext.Skilltables.Remove(value); //3.adım
            _portfolyodbContext.SaveChanges();
            return RedirectToAction("Index");
        }
      }
}
