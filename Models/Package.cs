namespace dive_deep.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PricePerDay { get; set; }

        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
