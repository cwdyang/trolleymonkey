using System;
using System.Collections.Generic;
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
        public JObject Get(JObject f)
        {

            var req = new MachineLearningRequest(new List<string> { "sales", "discounts", "day of week", "month", "season",
                               "timestart", "timened", "weather" });
            var list = new List<List<string>>
            {
                new List<string> { "5",	"1",	"3",	"6",	"Winter",			"23:00",	"23:29",	"Rain"},  
                new List<string> { "136",	"46",	"4",	"6",	"Winter",			"15:30",	"15:59",	"Clear"},
                new List<string> { "228",	"78",	"1",	"6",	"Winter",			"17:00",	"17:29",	"Partly cloudy"}
            };
            var result = req.Req(list);

            
            return result;
        }
    }
}