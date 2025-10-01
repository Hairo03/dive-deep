namespace dive_deep.Models
{
    public class DiveConditionsViewModel
    {
        public double WindSpeed { get; set; }
        public double WaveHeight { get; set; }
        public double Precipitation { get; set; }
        public bool Thunder { get; set; }
        public double WaterTemperature { get; set; }
        public bool Suitable { get; set; }
        public List<string> Messages { get; set; } = new();
        public string SuitRecommendation { get; set; } = string.Empty;
    }
}
