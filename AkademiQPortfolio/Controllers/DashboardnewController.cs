using Microsoft.AspNetCore.Mvc;
using AkademiQPortfolio.Data;
using System.Linq;



namespace AkademiQPortfolio.Controllers
{
    public class DashboardnewController : Controller
    {
        private readonly portfolyodbContext _context;

        public DashboardnewController(portfolyodbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ProjectCount = _context.ProjectsTables.Count();
            ViewBag.SkillCount = _context.Skilltables.Count();
            ViewBag.ServiceCount = _context.Services.Count();
            ViewBag.MessageCount = _context.Messages.Count();

            var lastMessages = _context.Messages
                .OrderByDescending(x => x.SendDate)
                .Take(3)
                .ToList();

            return View(lastMessages);
        }
    }

}
