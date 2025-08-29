namespace dive_deep.Models
{
    public enum Category
    {
        BCD,
        Regulator,
        Wetsuit,
        Fins,
        Mask,
        Snorkel,
        DiveComputer,
        Accessories,
        Tank
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerDay { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Thickness { get; set; }
        public string Gender { get; set; }
        public Category CategoryType { get; set; }




    }
}
