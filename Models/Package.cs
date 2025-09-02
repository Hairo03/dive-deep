namespace dive_deep.Models
{
    public class Package
    {
        public string Name { get; set; }
        public double PricePerDay { get; set; }
        public List<Product> Products { get; set; }
    }
}
