using System.Collections.Generic;

namespace WeatherAppWeb.Models
{
    public class WeatherResponse
    {
        public Clouds Clouds { get; set; }
        public Coord Coord { get; set; }
        public Main Main { get; set; }
        public Sys Sys { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public Wind Wind { get; set; }
        public string Base { get; set; }
        public int Visibility { get; set; }
        public int Dt { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
}
