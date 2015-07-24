using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

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
        public IEnumerable<string> Get()
        {
            var result = new List<string>();
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
                const string apiKey = "Z8RNo6HAvk3F5MsnJaK+zjQH3TQ4lFIOKQCFenUrNtVBlZ5ng8SBfpTcbsFrmY4gEONADqxTIIYzg9NDpvObmg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/771cf293c0e54a8c968f2c34f6f0d094/services/8b3d1825b5aa4fc0a399b2d443727320/execute?api-version=2.0&details=true");

                HttpResponseMessage response = client.PostAsJsonAsync("", scoreRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    result.Add(response.Content.ReadAsStringAsync().Result);
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