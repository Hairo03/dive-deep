using Microsoft.AspNetCore.Mvc;
using dive_deep.Models;
using dive_deep.Persistence;
using System.Linq;

namespace dive_deep.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int? id, string? searchTerm)
        {
            var products = id.HasValue
                ? ProductRepo.GetProductsByCategory(id.Value)
                : ProductRepo.GetAllProducts();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                products = ProductRepo.SearchProducts(searchTerm);
            }

            if (id.HasValue)
            {
                ViewBag.CategoryType = (Category)id.Value;
            }
            else
            {
                ViewBag.CategoryType = "Produkter";
            }

            return View(products);
        }
    }
}
