using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using WebApplication4.Domain;

namespace WebApplication4.Controllers
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }
    public class MachineLearningController : ApiController
    {

        // GET api/<controller>
        public JObject GetBusy()
        {
            const string season = "Winter";
            var weatherdescription = (new WeatherHelper()).GetCurrentWeather();

            var now = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.Now, "New Zealand Standard Time");
            now = now.Minute>29 ? new DateTime(now.Year, now.Month, now.Day, now.Hour, 30, 0) : new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);

            var req = new MachineLearningRequest(new List<string> { "discountCount", "dayOfWeek", "month", "season", "schoolholiday", "publichol", "wdtstart", "wdtend", "weatherdescription", "saleCount" });

            var result = new JObject();
            result["busyness"] = new JArray();
            for (var i = 0; i < 6; i++)
            {
                var list = new List<List<string>>();
                var time = now.AddMinutes(i*30);
                var wdtstart = string.Format("{0:00}:{1:00}", time.Hour, time.Minute);
                var wdtend = string.Format("{0:00}:{1:00}", time.Hour, (time + new TimeSpan(0, 0, 29, 0)).Minute);
                var timeslot = new List<string> { "0", ((int)now.DayOfWeek).ToString(), now.Month.ToString(), season, "0", "0", wdtstart, wdtend, weatherdescription, "0" };
                list.Add(timeslot);
                dynamic response = req.Req(list);
                var responseLine = response.Results.output1.value.Values[0];
                dynamic b = new JObject();
                b.time = wdtstart;
                b.color = LabelToTrafficLight(responseLine[8]);
                ((JArray) result["busyness"]).Add(b);
            }
            
            /*{
                  "business": [
                    {"07:00","green"},
                    {"07:30","NotBusy"},
                    {"08:00","NotBusy"},
                    {"08:30","NotBusy"}
                  ]
                }*/

            return result;
        }

        private string LabelToTrafficLight(JValue value)
        {
            if ((double) value > 0 && (double) value < 60) return "green";
            if ((double)value >= 60 && (double)value < 200) return "yellow";
            if ((double)value >= 200) return "red";
            return null;
        }
    }
}