using Microsoft.AspNetCore.Mvc;

namespace AkademiQPortfolio.ViewComponents;

    public class SkillViewComponent : ViewComponent
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
    

    public IViewComponentResult Invoke() 
        {
            return View();
        }
}
