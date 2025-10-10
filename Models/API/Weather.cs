namespace dive_deep.Models.API
{
    public class Weather
    {
        public List<string> Time { get; set; }
        public List<double> Wind_Speed_10M { get; set; }
        public List<int> Weather_Code { get; set; }
        public List<double> Precipitation { get; set; }
    }
}
