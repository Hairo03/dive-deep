using Microsoft.AspNetCore.Mvc;
using dive_deep.Models;
using dive_deep.Persistence;
using System.Linq;

namespace dive_deep.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo productRepo;
        public ProductsController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        public IActionResult Index(int? id, string? searchTerm)
        {
            var products = id.HasValue
                ? productRepo.GetProductsByCategory(id.Value)
                : productRepo.GetAllProducts();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                products = productRepo.SearchProducts(searchTerm);
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

        public IActionResult Inspect(int id)
        {
            Product product = productRepo.GetProductById(id);
            return View(product);
        }
    }
}
