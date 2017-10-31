using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string ParkCode { get; set; }
        public bool? IsFahrenheit { get; set; }

        public string Recommendation(string forecast, int low, int high)
        {
            string result = "";
            if(forecast == "sunny")
            {
                result += "Don't forget your sunscreen. ";
            }
            else if(forecast == "snow")
            {
                result += "Snowshoes reccomended. ";
            }
            else if(forecast == "thunderstorms")
            {
                result += "Seek shelter. Avoid hiking on exposed ridges. ";
            }
            else if(forecast == "rain")
            {
                result += "Pack raingear and a rubber ducky. Wear waterproof shoes. ";
            }
            else if(forecast == "partly cloudy")
            {
                return "We're still unsure which part will be cloudy. Check back later for details.";
            }
            else if(forecast == "partly cloudy")
            {
                return "This is Nathan's favourite weather.";
            }
            else
            {
                result += "";
            }
            if(low < 20)
            {
                result += "Brrr. Cold weather alert. Prolonged exposure can cause frostbite. ";
            }
            else if(high > 75)
            {
                result += "Due to warmer weather today, we advise that you carry an extra gallon of water on your person. ";
            }
            else
            {
                result += "";
            }
            if(high - low > 20)
            {
                result += "Wear breathable layers. ";
            }
            else
            {
                result += "";
            }
            return result;
        }

        public string DayForecast(int dayValue)
        {
            if (dayValue == 1)
            {
                return "Today";
            }

            else if (dayValue == 2)
            {
                return "Tommorow";
            }

            else if (dayValue == 3)
            {
                return "Three-day Forecast";
            }


            else if (dayValue == 4)
            {
                return "Four-day Forecast";
            }


            else if (dayValue == 5)
            {
                return "Five-day Forecast";
            }

            return "";
        }

        public string GetTemp(bool? isFahrenheit, double temperature)
        {
            if (isFahrenheit == false)
            {
                temperature = (temperature - 32) / 1.8;
                return temperature.ToString("0.0") + " C";
            }
            return temperature.ToString() + " F";
        }
    }
}