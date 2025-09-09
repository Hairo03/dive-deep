using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
