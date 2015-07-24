using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            var model = _settingsRepo.Get(id);
            return model;
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