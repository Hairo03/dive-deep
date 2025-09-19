using Microsoft.AspNetCore.Mvc;
using dive_deep.Models;
using dive_deep.Persistence;
using System.Linq;

namespace dive_deep.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IRepository<Package> _packageRepository;

        public ProductsController(IProductRepository productRepository, IRepository<Package> packageRepository)
        {
            _productRepository = productRepository;
            _packageRepository = packageRepository;
           
        }
        public IActionResult Index(int? id, string? searchTerm)
        {
            var products = id.HasValue
                ? _productRepository.GetProductsByCategory(id.Value)
                : _productRepository.GetAll();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                products = _productRepository.SearchProducts(searchTerm);
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
