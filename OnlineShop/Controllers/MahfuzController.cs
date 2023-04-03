using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class MahfuzController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
