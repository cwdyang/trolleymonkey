using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Linq;

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
        public JObject Get()
        {
            var result = new JObject();
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() { 
                        { 
                            "input1", 
                            new StringTable() 
                            {
                                ColumnNames = new string[] {"saleCount", "discountCount","dayOfWeek","month","season","schoolholiday","publichol","wdtstart","wdtend","weatherdescription"
},
                                Values = new string[,] {  { "0", "0","0","0","value","value","value","value","value","value"},  { "0", "0","0","0","value","value","value","value","value","value"},  }
                            }
                        },
                                        },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "p0bEX3Spi8916su2ta699/vaKzc+BGqr5Izq4wbMy+4XgESXEKCOPeXdfxDpS3A9lavBeEl9EpORDg0RDLTY8w=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/771cf293c0e54a8c968f2c34f6f0d094/services/8b3d1825b5aa4fc0a399b2d443727320/execute?api-version=2.0&details=true");

                HttpResponseMessage response = client.PostAsJsonAsync("", scoreRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    result= JObject.Parse(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    result.Add(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    result.Add(response.Headers.ToString());

                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    result.Add(responseContent);
                    
                }
            }
            return result;
        }
    }
}