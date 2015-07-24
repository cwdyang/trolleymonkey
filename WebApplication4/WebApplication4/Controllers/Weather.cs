using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication4.Controllers
{
    public class Weather
    {
        public void GetCurrentWeather()
        {
            var weatherRequest = WebRequest.Create("http://www.myweather2.com/developer/forecast.ashx?uac=Ou20ZRwTuX&output=json&query=SW1");
            weatherRequest.ContentType = "application/json";


            var weatherResults = new StreamReader(weatherRequest.GetResponse().GetResponseStream()).ReadToEnd();





        }



    }
}