using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WebApplication4.Domain
{
    public class WeatherHelper
    {
        public string GetCurrentWeather()
        {
            var weatherRequest = WebRequest.Create("http://www.myweather2.com/developer/forecast.ashx?uac=Ou20ZRwTuX&output=json&query=-36.8630231,174.8654693");
            weatherRequest.ContentType = "application/json";

            var weatherResults = new StreamReader(weatherRequest.GetResponse().GetResponseStream()).ReadToEnd();
            var deserializeObject = JsonConvert.DeserializeObject<Rootobject>(weatherResults);
            return MapWeatherCode(deserializeObject.weather.curren_weather[0].weather_code);
        }

        public string MapWeatherCode(string code)
        {
            var intCode = Convert.ToInt32(code);
            string weatherText;

            // #themappening
            switch (intCode)
            {
                case 1:
                    weatherText = "Partly cloudy";
                    break;
                case 10:
                    weatherText = "Few clouds";
                    break;
                case 2:
                case 3:
                case 45:
                case 49:
                    weatherText = "Cloudy";
                    break;
                case 29:
                case 91:
                case 92:
                case 93:
                case 94:
                    weatherText = "Thunder";
                    break;
                case 21:
                case 22:
                case 23:
                case 24:
                case 38:
                case 39:
                case 50:
                case 51:
                case 56:
                case 57:
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                    weatherText = "Rain";
                    break;
                case 0:
                    weatherText = "Clear";
                    break;
                default:
                    weatherText = "clear";
                    break;
            }
            return weatherText;
        }
    }
}