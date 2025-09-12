using dive_deep.Models;

namespace dive_deep.Persistence
{
    public static class PackageRepo
    {
        private static List<Package> packages = new List<Package>()
        {
            //new Package() { Name = "Komplet Dykkersæt", PricePerDay = 900, Products = new List<Product>() {ProductRepo.GetProductById(0),ProductRepo.GetProductById(1)} },
            //new Package() { Name = "Snorkelsæt", PricePerDay = 300, Products = new List<Product>() { ProductRepo.GetProductById(2), ProductRepo.GetProductById(3) } }
        };
        public static IEnumerable<Package> GetAllPackages()
        {
            return packages;
        }
    }
}
