using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Http;
using DataAccess.Repos;
using Newtonsoft.Json.Linq;

namespace WebApplication4.Controllers
{
    public class DistanceController : ApiController
    {
        private readonly StoreRepo _storeRepo;

        public DistanceController()
        {
            _storeRepo = new StoreRepo();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            string origin = "-36.851188, 174.761664";
            string destination = "New World Supermarket Victoria+Park, 2 College Hill, Freemans+Bay, Auckland 1011";
            var url =
                string.Format(
                    "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&mode=driving&key=AIzaSyDQOysQzFL2oFtYCMnkLtH-DEkFT-GdGR4",
                    HttpUtility.UrlEncode(origin), HttpUtility.UrlEncode(destination));
            var trafficRequest = WebRequest.Create(url);
            trafficRequest.ContentType = "application/json";
            dynamic trafficResults = JObject.Parse(new StreamReader(trafficRequest.GetResponse().GetResponseStream()).ReadToEnd());

            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }

        // POST api/<controller>
        [HttpPost]
        public JObject Post([FromUri]int id, [FromBody] JObject latlon)
        {
            string origin = string.Format("{0}, {1}", latlon["lat"], latlon["lon"]);
            //var store = _storeRepo.Get(id);
            string destination = "New World Supermarket Victoria+Park, 2 College Hill, Freemans+Bay, Auckland 1011";
            var url =
                string.Format(
                    "https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&mode=driving&key=AIzaSyDQOysQzFL2oFtYCMnkLtH-DEkFT-GdGR4",
                    HttpUtility.UrlEncode(origin), HttpUtility.UrlEncode(destination));
            var trafficRequest = WebRequest.Create(url);
            trafficRequest.ContentType = "application/json";
            dynamic trafficResults = JObject.Parse(new StreamReader(trafficRequest.GetResponse().GetResponseStream()).ReadToEnd());
            var firstRoute = trafficResults.routes[0];
            dynamic result = new JObject();
            if (firstRoute == null) return result;
            result.distance = firstRoute.legs[0].distance;
            result.duration = firstRoute.legs[0].duration;
            return result;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new HttpResponseException(HttpStatusCode.NotImplemented);
        }
    }
}