using Microsoft.AspNetCore.Mvc;
using dive_deep.Models;
using dive_deep.Persistence;

namespace dive_deep.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                return View(ProductRepo.GetProductsByCategory(id.Value));
            }
            return View(ProductRepo.GetAllProducts());
        }
    }
}
