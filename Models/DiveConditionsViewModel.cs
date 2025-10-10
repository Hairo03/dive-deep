namespace dive_deep.Models
{
    public class DiveConditionsViewModel
    {
        public DiveConditionsViewModel(double windSpeed, double? waveHeight, double precipation, int weatherCode)
        {
            WindSpeed = windSpeed;
            WaveHeight = waveHeight;
            Precipitation = precipation;
            if (weatherCode == 29)
            {
                Thunder = true;
            }
            else
            {
                Thunder = false;
            }
        }

        public double WindSpeed { get; set; }
        public double? WaveHeight { get; set; }
        public double Precipitation { get; set; }
        public bool Thunder { get; set; }
    }
}
