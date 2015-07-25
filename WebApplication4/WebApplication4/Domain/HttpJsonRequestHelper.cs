using System;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Domain
{
    public class HttpJsonRequestHelper
    {
        public static JObject MakeJsonHttpPostRequest(string url, JObject data, HttpClient clientToUse = null)
        {
            var result = new JObject();
            using (var client = clientToUse ?? new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var response = client.PostAsJsonAsync("", data).Result;

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

        public static JObject MakeJsonHttpGetRequest(string url, JObject data, HttpClient clientToUse = null)
        {
            var result = new JObject();
            using (var client = clientToUse ?? new HttpClient())
            {
                client.BaseAddress = new Uri(String.Format("{0}?{1}", url, HttpUtility.UrlEncode(data.ToString())));
                var response = client.GetAsync("").Result;

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
            //trafficRequest.ContentType = "application/json";
        }
    }
}