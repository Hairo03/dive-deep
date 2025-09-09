using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View(PackageRepo.GetAllPackages());
        }
    }
}
