using AkademiQPortfolio.Data; // DbContext'in namespace'i
using AkademiQPortfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include için gerekli
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly portfolyodbContext _context; // DbContext

    public HomeController(ILogger<HomeController> logger, portfolyodbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Projects()
    {
        var projects = _context.ProjectsTables
                               .Include(p => p.Category) // kategori bilgisini de çek
                               .ToList();
        return View(projects);
    }
    [HttpGet("Home/ProjeDetay/{id}")] // Bu satırı metodun tam üstüne ekle
    public IActionResult ProjeDetay(int id)
    {
        var proje = _context.ProjectsTables
                            .Include(p => p.Category)
                            .FirstOrDefault(x => x.ProjectId == id);

        if (proje == null) return NotFound();

        return View(proje);
    }
    public IActionResult About()
    {
        return View(); // Views/Home/About.cshtml'i render eder
    }
    public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Contact(string name, string email, string message)
    {
        try
        {
            // Veritabanına kaydet
            var newMessage = new Message
            {
                NameSurname = name,
                Mail = email,
                Subject = "İletişim Formu", // veya Subject alanını da formdan alabilirsin
                MessageContent = message,
                SendDate = DateTime.Now
            };

            _context.Messages.Add(newMessage);
            _context.SaveChanges();

            // İsteğe bağlı: Mail gönder
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("GONDERENMAIL@gmail.com");
                mail.To.Add("SENINMAIL@gmail.com");
                mail.Subject = "Portfolio İletişim Formu";
                mail.Body = $"Ad: {name}\nEmail: {email}\n\nMesaj:\n{message}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("GONDERENMAIL@gmail.com", "APP_PASSWORD");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception mailEx)
            {
                _logger.LogError($"Mail gönderilemedi: {mailEx.Message}");
            }

            TempData["Success"] = "Mesajınız başarıyla gönderildi! 🎉";
        }
        catch (Exception ex)
        {
            _logger.LogError($"Mesaj kaydedilemedi: {ex.Message}");
            TempData["Error"] = "Bir hata oluştu, lütfen tekrar deneyin.";
        }

        return RedirectToAction("Contact");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
