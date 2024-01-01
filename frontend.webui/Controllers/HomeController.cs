using Microsoft.AspNetCore.Mvc;

namespace frontend.webui.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
