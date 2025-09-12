using dive_deep.Models;

namespace dive_deep.Persistence
{
    public class ProductRepo : IProductRepo
    {
        private List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 0,
                Brand = "Scubapro",
                Name = "Navigator Lite BCD",
                PricePerDay = 125,
                CategoryType = Category.BCD
            },
            new Product
            {
                Id = 1,
                Brand = "Scubapro",
                Name = "BCD Glide",
                PricePerDay = 100,
                CategoryType = Category.BCD
            },
            new Product
            {
                Id = 2,
                Brand = "Scubapro",
                Name = " Definition",
                PricePerDay = 100,
                CategoryType = Category.Wetsuit
            },
            new Product
            {
                Id = 3,
                Brand = "Scubapro",
                Name = "5 liter tank",
                PricePerDay = 150,
                CategoryType = Category.Tank
            },
            new Product
            {
                Id = 4,
                Brand = "Subapro",
                Name = "MK25EVO",
                PricePerDay = 125,
                CategoryType = Category.Regulator
            },
            new Product
            {
                Id = 5,
                Brand = "Scubapro",
                Name = "Ghost",
                PricePerDay = 50,
                CategoryType = Category.Wetsuit
            },
            new Product
            {
                Id = 6,
                Brand = "Seac",
                Name = "ALA",
                PricePerDay = 50,
                CategoryType = Category.Fins
            },
            new Product
            {
                Id = 7,
                Brand = "Cressi",
                Name = "F1",
                PricePerDay = 50,
                CategoryType = Category.Mask
            },
            new Product
            {
                Id = 8,
                Brand = "Cressi",
                Name = "Snorkel",
                PricePerDay = 25,
                CategoryType = Category.Snorkel
            }

        };
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return products.Where(p => p.CategoryType == (Category)id);
        }

        public Product GetProductById(int id)
        {
            Product product;
            foreach (Product p in products)
            {
                if (p.Id == id)
                {
                    product = p;
                    return product;
                }
            }
            return null;
        }

        public IEnumerable<Product> SearchProducts(string? searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            List<Product> filteredProducts = products
                .Where(p =>
                    (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Brand) && p.Brand.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Size) && p.Size.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Thickness) && p.Thickness.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrEmpty(p.Gender) && p.Gender.ToLower().Contains(searchTerm)) ||
                    p.CategoryType.ToString().ToLower().Contains(searchTerm)
                )
                .ToList();
            return filteredProducts;
        }
    }
}





