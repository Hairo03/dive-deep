using dive_deep.Models;
using dive_deep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace dive_deep.Controllers
{
    public class PackageController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Package> _packageRepository;

        public PackageController(IRepository<Product> productRepository, IRepository<Package> packageRepository)
        {
            _productRepository = productRepository;
            _packageRepository = packageRepository;

        }
        public IActionResult Index()
        {
            return View(_packageRepository.GetAll());
        }
    }
}
