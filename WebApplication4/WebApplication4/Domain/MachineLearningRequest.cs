using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Domain
{
    public class MachineLearningRequest
    {
        private readonly List<string> _columnNames;

        public MachineLearningRequest(List<string> columnNames)
        {
            _columnNames = columnNames ??
                           new List<string>
                           {
                               "saleCount", "discountCount", "dayOfWeek", "month", "season", "schoolholiday", "publichol",
                               "wdtstart", "wdtend", "weatherdescription"
                           };
        }

        public JObject Req(List<List<string>> parameters)
        {
            var result = new JObject();
            using (var client = new HttpClient())
            {
                var scoreRequest = new JObject();
                scoreRequest["Inputs"] = new JObject();
                scoreRequest["Inputs"]["input1"] = new JObject();
                scoreRequest["Inputs"]["input1"]["ColumnNames"] = new JArray(_columnNames);
                var columns = new JArray();
                foreach (var line in parameters.Select(p => new JArray(p)))
                {
                    columns.Add(line);
                }
                scoreRequest["Inputs"]["input1"]["Values"] = columns;
                scoreRequest["GlobalParameters"] = new JObject();

                const string apiKey = "p0bEX3Spi8916su2ta699/vaKzc+BGqr5Izq4wbMy+4XgESXEKCOPeXdfxDpS3A9lavBeEl9EpORDg0RDLTY8w=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/771cf293c0e54a8c968f2c34f6f0d094/services/8b3d1825b5aa4fc0a399b2d443727320/execute?api-version=2.0&details=true");

                var response = client.PostAsJsonAsync("", scoreRequest).Result;

                if (response.IsSuccessStatusCode)
                {
                    result = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    result.Add(string.Format("The request failed with status code: {0}", response.StatusCode));
                    // Print the headers - they include the requert ID and the timestamp, which are useful for debugging the failure
                    result.Add(response.Headers.ToString());
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    result.Add(responseContent);
                }
            }
            return result;
        }
    }
}