using System;
using System.Net;
using System.Web.Http;
using DataAccess.Repos;
using DataAccess.ViewModels;

namespace WebApplication4.Controllers
{
    public class SettingsController : ApiController
    {

        private readonly SettingsRepo _settingsRepo;

        public SettingsController()
        {
            _settingsRepo = new SettingsRepo();
        }

        // GET api/<controller>/5
        public Settings Get(int id)
        {
            var result = _settingsRepo.Get(id);
            if (result == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return result;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}