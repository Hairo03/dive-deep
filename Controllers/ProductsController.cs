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

                searchTerm = searchTerm.ToLower();

                products = products
                    .Where(p =>
                        (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(p.Brand) && p.Brand.ToLower().Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(p.Size) && p.Size.ToLower().Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(p.Thickness) && p.Thickness.ToLower().Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(p.Gender) && p.Gender.ToLower().Contains(searchTerm)) ||
                        p.CategoryType.ToString().ToLower().Contains(searchTerm) 
                    )
                    .ToList();

            }

            return View(products);
        }
    }
}
