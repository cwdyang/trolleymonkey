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
            _columnNames = columnNames;
            if(columnNames==null)
                throw new Exception("need columns");
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

                const string apiKey = "IIeq54kFAHq/wcDb+eEjJMIFdz4rKp6GlBI+7U+LjDxHQFaMborPveuTJ8ro0sgqrhUEX9b44Y7EPkTB6O0Ucg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/771cf293c0e54a8c968f2c34f6f0d094/services/710f683e734a44c8b36577746989bdf7/execute?api-version=2.0&details=true");

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