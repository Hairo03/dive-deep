using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
